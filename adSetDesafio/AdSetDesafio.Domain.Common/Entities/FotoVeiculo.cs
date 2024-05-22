using AdSetDesafio.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdSetDesafio.Domain.Common.Entities
{
    [Table("FotoVeiculo")]
    public class FotoVeiculo : Entity, IAggregateRoot
    {
        public int IdVeiculo { get; set; }

        public int IdGuid { get; set; }

        public string Arquivo { get; set; }

        public string Nome { get; set; }
    }
}