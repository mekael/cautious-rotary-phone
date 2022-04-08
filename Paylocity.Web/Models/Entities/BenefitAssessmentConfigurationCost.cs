using Paylocity.Web.Models.Enums;
using System;
namespace Paylocity.Web.Models.Entities
{
    // this is a terrible name for this class. 
    public class BenefitAssessmentConfigurationCost : EntityBase
    {
        public Guid BenefitAssessmentConfigurationId { get; set; }
        public BenefitAssessmentConfiguration BenefitAssessmentConfiguration { get; set; }
        public PersonType PersonType { get; set; }
        public float CostPerYear { get; set; }
        public bool HasNameBasedDiscount { get; set; }
        public float DiscountPercentage { get; set; }
        public NameDiscountMatchingType NameDiscountMatchingType { get; set; }

    }
}
