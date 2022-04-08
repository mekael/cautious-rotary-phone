using System;

namespace Paylocity.Web.Models.Entities
{
    public class BenefitAssessmentConfigurationPayPeriod : EntityBase
    {
        public Guid BenefitAssessmentConfigurationId { get; set; }
        public BenefitAssessmentConfiguration BenefitAssessmentConfiguration { get; set; }
        public DateTime PayPeriodStartDate { get; set; }
        public DateTime PayPeriodEndDate { get; set; } 
        public DateTime PayPeriodPayDate { get; set; }
    }
}
