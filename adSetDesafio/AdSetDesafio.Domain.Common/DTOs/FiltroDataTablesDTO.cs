using System.Collections.Generic;

namespace AdSetDesafio.Domain.Common.DTOs
{
    public class FiltroDataTables
    {
        public FiltroDataTables()
        {
            search = new DataTablesFiltro();
            
        }
        
        public int draw { get; set; }
        
        public int start { get; set; }
        
        public int length { get; set; }
        
        public List<DataTablesColunas> columns { get; set; }
        
        public DataTablesFiltro search { get; set; }
        
        public List<DataTablesOrdem> order { get; set; }
    }
}