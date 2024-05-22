using FluentValidation;

namespace AdSetDesafio.Domain.Commands.Veiculo.Validations
{
    public class VeiculoValidator<T> : AbstractValidator<T>
        where T : VeiculoCommand
    {
        public VeiculoValidator()
        {
            //criar validações para regras de negocio
        }
    }
}