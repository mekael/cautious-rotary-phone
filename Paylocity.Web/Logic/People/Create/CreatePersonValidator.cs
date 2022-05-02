using FluentValidation;
using System;

namespace Paylocity.Web.Logic.People.Create
{
    public class CreatePersonValidator : AbstractValidator<CreatePerson>
    {
        public CreatePersonValidator()
        {
            RuleFor(r => r).NotNull();
            RuleFor(r => r.EmployeeId).NotEmpty();
            RuleFor(r => r.DateOfDeath).Must(m => !m.HasValue || m.Value.Date <= DateTime.Today);
            RuleFor(r => r.DateOfBirth).Must(m => !m.HasValue || m.Value.Date <= DateTime.Today);
            RuleFor(r => r).Must(ValidateBirthDeathRelationship);
            RuleFor(r => r.FirstName).NotEmpty();
            RuleFor(r => r.LastName).NotEmpty();



        }

        bool ValidateBirthDeathRelationship(CreatePerson createPerson)
        {
            if (createPerson.DateOfBirth.HasValue && createPerson.DateOfDeath.HasValue
                   && createPerson.DateOfBirth.Value.Date > createPerson.DateOfDeath.Value.Date)
            {
                return false;
            }
            else if (!createPerson.DateOfBirth.HasValue && createPerson.DateOfDeath.HasValue) {
                return false;
            }
            else
            {
                return true;
            }

         }
    }
}
