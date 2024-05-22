using ADSET.Application.Validators;
using FluentValidation;

namespace ADSET.Application.DTOs.Requests
{
    public class VeiculoRequest
    {
        public Guid MarcaId { get; set; }
        public Guid ModeloId { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public int Km { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public List<Guid>? Opcionais { get; set; }

        public void Validate()
        {
            VeiculoRequestValitador validator = new();

            validator.ValidateAndThrow(this);
        }
    }
}
