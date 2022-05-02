using FluentValidation;

namespace Paylocity.Web.Logic.People.PersonAddress.Create
{
    public class CreateAddressValidator :AbstractValidator<CreateAddress>
    {
        public CreateAddressValidator()
        {
            RuleFor(r => r).NotNull();
            RuleFor(r => r.PersonId).NotEmpty().Unless(u => u == null);
            RuleFor(r => r.AddressLineOne).NotEmpty().Unless(u => u == null);
            RuleFor(r => r.City).NotEmpty().Unless(u => u == null);
            RuleFor(r => r.State).NotEmpty().Unless(u => u == null);
            RuleFor(r => r.ZipCode).NotEmpty().Unless(u => u == null);
        }
    }
}
