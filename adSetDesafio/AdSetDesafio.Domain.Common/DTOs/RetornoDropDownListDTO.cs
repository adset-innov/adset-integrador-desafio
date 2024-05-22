using System.Collections.Generic;

namespace AdSetDesafio.Domain.Common.DTOs
{
    public class RetornoDropDownListDTO
    {
        public int total { get; set; }

        public IEnumerable<RetornoDropDownListItemDTO> results { get; set; }
    }

    public class RetornoDropDownListItemDTO
    {
        public object id { get; set; }

        public string text { get; set; }
    }
}