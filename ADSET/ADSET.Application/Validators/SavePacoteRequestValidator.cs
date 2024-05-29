using ADSET.Application.DTOs.Requests;
using FluentValidation;

namespace ADSET.Application.Validators
{
    public class SavePacoteRequestValidator : AbstractValidator<SavePacoteRequest>
    {
        public SavePacoteRequestValidator()
        {
            RuleFor(p => p.VeiculoId)
                .NotEmpty();
        }
    }
}
