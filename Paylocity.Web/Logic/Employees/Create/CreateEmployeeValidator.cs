using FluentValidation;

namespace Paylocity.Web.Logic.Employees.Create
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployee>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(r => r).NotNull();
        }
    }
}
