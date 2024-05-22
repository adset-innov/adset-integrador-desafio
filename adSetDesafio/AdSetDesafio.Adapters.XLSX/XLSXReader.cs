using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using ExcelMapper;
using AdSetDesafio.Domain.Common.Interfaces;

namespace AdSetDesafio.Adapters.XLSX
{
    public class XLSXReader : IAdapterReader
    {
        private readonly ExcelReaderConfiguration _configuration;
        public XLSXReader()
        {
            _configuration = new ExcelReaderConfiguration();
        }

        public void SetConfiguration(Encoding encoding)
        {
            _configuration.FallbackEncoding = encoding;
        }

        public async Task<IList<TEntity>> ReadDataAsync<TEntity>(string path)
        {
            using var stream = File.Open(path, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelDataReader;
            excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream, _configuration);

            var importer = new ExcelImporter(excelDataReader);
            ExcelSheet sheet = importer.ReadSheet(0);

            List<TEntity> models = sheet.ReadRows<TEntity>()
                .Where(x => !AllPropertiesAreNull(x))
                .ToList();

            return models;
        }
        private static bool AllPropertiesAreNull(object obj)
        {
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                if (property.GetValue(obj) != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
