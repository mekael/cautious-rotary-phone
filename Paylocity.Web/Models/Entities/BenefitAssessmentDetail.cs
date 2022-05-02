using System;

namespace Paylocity.Web.Models.Entities
{
    public class BenefitAssessmentDetail : EntityBase
    {
        public Guid BenefitAssessmentId { get; set; }
        public BenefitAssessment BenefitAssessment { get; set; }

    }
}
