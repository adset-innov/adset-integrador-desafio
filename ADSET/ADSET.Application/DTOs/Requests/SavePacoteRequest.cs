using ADSET.Application.DTOs.Enums;
using ADSET.Application.Validators;
using FluentValidation;

namespace ADSET.Application.DTOs.Requests
{
    public class SavePacoteRequest
    {
        public Guid VeiculoId { get; set; }
        public List<TipoPacote> Pacotes { get; set; }

        public SavePacoteRequest(Guid veiculoId, List<TipoPacote> pacotes)
        {
            this.VeiculoId = veiculoId;
            this.Pacotes = pacotes;
        }

        public void Validate()
        {
            SavePacoteRequestValidator validator = new();

            validator.ValidateAndThrow(this);
        }
    }
}
