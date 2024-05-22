using FluentValidation;

namespace AdSetDesafio.Domain.Commands.Veiculo.Validations
{
    public class VeiculoValidatorUpdate : VeiculoValidator<VeiculoCommandUpdate>
    {
        public VeiculoValidatorUpdate() : base()
        {
            this.ValidateId();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .WithMessage("Registro não encontrado");
        }
    }
}