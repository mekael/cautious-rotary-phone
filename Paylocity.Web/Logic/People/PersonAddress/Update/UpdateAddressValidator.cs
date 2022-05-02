using FluentValidation;

namespace Paylocity.Web.Logic.People.PersonAddress.Update
{
    public class UpdateAddressValidator :AbstractValidator<UpdateAddress>
    {
        public UpdateAddressValidator()
        {
            RuleFor(r => r).NotNull();
            RuleFor(r => r.PersonId).NotEmpty().Unless(u => u == null);
            RuleFor(r => r.AddressId).NotEmpty().Unless(u => u == null);
            RuleFor(r => r.AddressLineOne).NotEmpty().Unless(u => u == null);
            RuleFor(r => r.City).NotEmpty().Unless(u => u == null);
            RuleFor(r => r.State).NotEmpty().Unless(u => u == null);
            RuleFor(r => r.ZipCode).NotEmpty().Unless(u => u == null);
        }
    }
}
