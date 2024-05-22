using AdSetDesafio.Domain.Commands.Veiculo.Validations;

namespace AdSetDesafio.Domain.Commands.Veiculo
{
    public class VeiculoCommandDelete : Command
    {
        public override bool IsValid()
        {
            ValidationResult = new VeiculoValidatorDelete().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}