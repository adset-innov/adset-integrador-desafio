using System;
using AdSetDesafio.Domain.Common.Interfaces;

namespace AdSetDesafio.Domain.Common.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
