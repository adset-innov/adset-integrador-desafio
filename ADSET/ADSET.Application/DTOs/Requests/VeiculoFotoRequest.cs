using ADSET.Application.Validators;
using FluentValidation;

namespace ADSET.Application.DTOs.Requests
{
    public class VeiculoFotoRequest
    {
        public Guid VeiculoId { get; set; }
        public string Nome { get; set; }
        public Stream Stream { get; set; }
        public string ContentType { get; set; }

        public void Validate()
        {
            VeiculoFotoRequestValidator validator = new();

            validator.ValidateAndThrow(this);
        }
    }
}
