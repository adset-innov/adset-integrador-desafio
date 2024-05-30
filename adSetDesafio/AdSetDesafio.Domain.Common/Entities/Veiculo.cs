using AdSetDesafio.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdSetDesafio.Domain.Common.Entities
{
    [Table("Veiculo")]
    public class Veiculo : Entity, IAggregateRoot
    {

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Ano { get; set; }

        public string Placa { get; set; }

        public int Km { get; set; }

        public string Cor { get; set; }

        public decimal Preco { get; set; }

        public int? IdOpcional { get; set; }

        public int? PacoteICarros { get; set; }

        public int? PacoteWebMotors { get; set; }

        public List<string> Fotos { get; set; }
    }
}