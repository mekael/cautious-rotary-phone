using Paylocity.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paylocity.Web.Logic.Configuration.Create
{
    public class CreateBenefitAssessmentConfiguration
    {
        public CreateBenefitAssessmentConfiguration()
        {
            Enum.GetValues<PersonType>().Cast<PersonType>().ToList().ForEach(item =>
              CreateBenefitAssessmentConfigurationPersonCosts.Add(new CreateBenefitAssessmentConfigurationPersonCost() { PersonType = item })
            );


        }
        public DateTime StartOfYear { get; set; }
        public int NumberOfPayPeriodsPerYear { get; set; } = 1;
        public float PerPayPeriodSalary { get; set; } = 2000;
        public DateTime ActiveAsOfDate { get; set; } = DateTime.Today;
        public List<CreateBenefitAssessmentConfigurationPersonCost> CreateBenefitAssessmentConfigurationPersonCosts { get; set; } = new List<CreateBenefitAssessmentConfigurationPersonCost>();
    }

    public class CreateBenefitAssessmentConfigurationPersonCost
    {
        public PersonType PersonType { get; set; }
        public float CostPerYear { get; set; }
        public bool HasNameBasedDiscount { get; set; }
        public float DiscountPercentage { get; set; }
        public NameDiscountMatchingType NameDiscountMatchingType { get; set; }
    }
}
