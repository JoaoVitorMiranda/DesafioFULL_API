using FluentValidation;
using Paschoalotto.Devedor.Domain.Models;

namespace Paschoalotto.Devedor.Domain.Validation.CustomerValidation
{
    public class CustomerDeleteValidation : AbstractValidator<Customer>
    {
        public CustomerDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id não pode ser nulo");
        }
    }
}
