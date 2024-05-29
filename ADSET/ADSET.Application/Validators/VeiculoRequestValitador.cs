using ADSET.Application.DTOs.Requests;
using FluentValidation;

namespace ADSET.Application.Validators
{
    public class VeiculoRequestValitador : AbstractValidator<VeiculoRequest>
    {
        public VeiculoRequestValitador()
        {
            RuleFor(x => x.MarcaId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Selecione uma marca");

            RuleFor(x => x.ModeloId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Selecione um modelo");

            RuleFor(x => x.Ano)
                .NotNull()
                .NotEmpty()
                .WithMessage("Selecione o ano do veiculo");

            RuleFor(x => x.Cor)
                .NotNull()
                .NotEmpty()
                .WithMessage("Insira uma cor valida");

            RuleFor(x => x.Placa)
                .Length(7).WithMessage("A placa deve ter 7 caracteres")
                .NotNull()
                .NotEmpty()
                .WithMessage("Insira uma placa valida");

        }
    }
}
