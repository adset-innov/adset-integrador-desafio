using ADSET.Application.DTOs.Requests;
using FluentValidation;

namespace ADSET.Application.Validators
{
    public class VeiculoFotoRequestValidator : AbstractValidator<VeiculoFotoRequest>
    {
        public VeiculoFotoRequestValidator()
        {
            RuleFor(x => x.VeiculoId)
                .NotEmpty()
                .NotNull();
            
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.ContentType)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.ContentType)
                .NotNull()
                .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("File type is larger than allowed");
        }
    }
}
