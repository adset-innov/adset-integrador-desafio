using AdSetDesafio.Domain.Commands.Veiculo.Validations;

namespace AdSetDesafio.Domain.Commands.Veiculo
{
    public class VeiculoCommandUpdate : VeiculoCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new VeiculoValidatorUpdate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}