using System;
using System.Collections.Generic;

namespace Paylocity.Web.Models.Entities
{
    public class BenefitAssessmentConfiguration : EntityBase
    {
        public DateTime StartOfYear { get; set; }
        public int NumberOfPayPeriodsPerYear { get; set; }
        public float PerPayPeriodSalary { get; set; }
        public ICollection<BenefitAssessmentConfigurationCost> BenefitAssessmentConfigurationCosts { get; set; }
        public ICollection<BenefitAssessmentConfigurationPayPeriod> BenefitAssessmentConfigurationPayPeriods { get; set; }
    }
}
