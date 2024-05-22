using AdSetDesafio.Adapters.XLSX.Attributes;
using AdSetDesafio.Domain.Common.Interfaces;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdSetDesafio.Adapters.XLSX
{
    public class XLSXWriter : IAdapterWriter
    {
        public XLSXWriter()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public async Task<string> WriteDataAsync<TEntity>(IList<TEntity> entities, string path)
        {
            var fi = new FileInfo(path);

            try
            {
                using var p = new ExcelPackage();
                var ws = p.Workbook.Worksheets.Add(entities.First().GetType().Name);

                var headers = GetHeaders(entities.First(), out List<int> columnPositionNotIgnoreExports);
                for (int headerIndex = 0; headerIndex < headers.Count; headerIndex++)
                {
                    ws.Cells[1, headerIndex + 1].Value = headers[headerIndex];

                    ws.Cells[1, headerIndex + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, headerIndex + 1].Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    ws.Cells[1, headerIndex + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ED7D31"));
                    ws.Cells[1, headerIndex + 1].Style.Font.Bold = true;
                }

                for (int rowIndex = 0; rowIndex < entities.Count; rowIndex++)
                {
                    var properties = entities[rowIndex].GetType().GetProperties();
                    foreach (var i in columnPositionNotIgnoreExports)
                    {
                        ws.Cells[rowIndex + 2, columnPositionNotIgnoreExports.IndexOf(i) + 1].Value = properties[i].GetValue(entities[rowIndex], null);
                    }
                }

                ws.Cells.AutoFitColumns();
                await p.SaveAsAsync(fi);
                return path;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IList<string> GetHeaders<TEntity>(TEntity item, out List<int> columnPositionNotIgnoreExports)
        {
            List<string> headers = new();
            columnPositionNotIgnoreExports = new List<int>();

            var properties = item.GetType().GetProperties();

            for (int columnCounter = 0; columnCounter < properties.Length; columnCounter++)
            {
                columnPositionNotIgnoreExports.Add(columnCounter);

                object[] attrs = properties[columnCounter].GetCustomAttributes(true);

                string header = string.Empty;

                bool ignoreExport = false;
                foreach (object attr in attrs)
                {
                    HeaderAttribute headerAttr = attr as HeaderAttribute;

                    if (headerAttr != null)
                    {
                        header = headerAttr.Name;
                    }
                }

                if (!ignoreExport)
                {
                    if (header == string.Empty)
                        header = properties[columnCounter].Name;
                    headers.Add(header);
                }
            }
            return headers;
        }
    }
}
