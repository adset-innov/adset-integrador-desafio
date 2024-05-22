using AdSetDesafio.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdSetDesafio.Domain.Common.Entities
{
    [Table("Opcional")]
    public class Opcional : Entity, IAggregateRoot
    {

        public string Nome { get; set; }

    }
}