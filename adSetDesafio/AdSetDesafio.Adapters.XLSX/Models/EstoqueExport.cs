using AdSetDesafio.Adapters.XLSX.Attributes;
using System;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace AdSetDesafio.Adapters.XLSX.Models
{
    public class VeiculoExport
    {
        [Header(Name = "Marca")]
        public string Marca { get; set; }

        [Header(Name = "Modelo")]
        public string Modelo { get; set; }

        [Header(Name = "Ano")]
        public int Ano { get; set; }
      
        [Header(Name = "Placa")]
        public string Placa { get; set; }

        [Header(Name = "Km")]
        public int? Km { get; set; }

        [Header(Name = "Cor")]
        public string Cor { get; set; }

        [Header(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}
