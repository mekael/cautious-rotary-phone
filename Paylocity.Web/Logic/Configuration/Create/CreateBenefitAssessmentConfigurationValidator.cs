using FluentValidation;
using System;

namespace Paylocity.Web.Logic.Configuration.Create
{
    public class CreateBenefitAssessmentConfigurationValidator : AbstractValidator<CreateBenefitAssessmentConfiguration>
    {
        public CreateBenefitAssessmentConfigurationValidator() {
            RuleFor(r => r).NotNull();
            RuleFor(r => r.CreateBenefitAssessmentConfigurationPersonCosts).NotEmpty().Unless(u=> u==null);
            RuleFor(r=> r.NumberOfPayPeriodsPerYear).GreaterThan(0).Unless(u => u == null);
            RuleFor(r=> r.PerPayPeriodSalary).GreaterThan(0).Unless(u => u == null);
            RuleFor(r => r.StartOfYear).GreaterThan(DateTime.ParseExact("20000101", "yyyyMMdd",null)).Unless(u => u == null);
            RuleFor(r => r.ActiveAsOfDate).GreaterThanOrEqualTo(DateTime.Today);
        }

    }
}
