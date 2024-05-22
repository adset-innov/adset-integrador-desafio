using AdSetDesafio.Domain.Commands.Veiculo.Validations;

namespace AdSetDesafio.Domain.Commands.Veiculo
{
    public class VeiculoCommandCreate : VeiculoCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new VeiculoValidator<VeiculoCommandCreate>().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}