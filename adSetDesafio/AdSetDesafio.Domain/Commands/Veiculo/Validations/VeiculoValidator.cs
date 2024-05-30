using FluentValidation;

namespace AdSetDesafio.Domain.Commands.Veiculo.Validations
{
    public class VeiculoValidator<T> : AbstractValidator<T>
        where T : VeiculoCommand
    {
        public VeiculoValidator()
        {
            this.ValidateVeiculoMarca();
        }

        void ValidateVeiculoMarca()
        {
            RuleFor(c => c.Marca)
                .NotEmpty()
                .WithMessage("O Campo Marca deve estar preenchido.");
        }
    }
}