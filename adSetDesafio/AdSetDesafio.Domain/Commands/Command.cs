using System;
using MediatR;
using FluentValidation.Results;

namespace AdSetDesafio.Domain.Commands
{
    public abstract class Command : IRequest<ValidationResult>
    {
        public int Id { get; set; }

        public Guid AggregateId { get; set; }

        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            AggregateId = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}