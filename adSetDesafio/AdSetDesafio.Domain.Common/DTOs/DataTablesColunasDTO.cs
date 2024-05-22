using AdSetDesafio.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdSetDesafio.Domain.Common.DTOs
{
    public class DataTablesColunas
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public FieldTypeEnum Type { get; set; }
        public DataTablesFiltro search { get; set; }
    }
}
