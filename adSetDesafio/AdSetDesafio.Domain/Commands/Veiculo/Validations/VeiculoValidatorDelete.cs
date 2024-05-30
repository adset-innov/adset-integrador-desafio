using FluentValidation;

namespace AdSetDesafio.Domain.Commands.Veiculo.Validations
{
    public class VeiculoValidatorDelete : AbstractValidator<VeiculoCommandDelete>
    {
        public VeiculoValidatorDelete()
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