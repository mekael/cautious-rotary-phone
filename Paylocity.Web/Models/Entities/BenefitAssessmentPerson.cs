using Paylocity.Web.Models.Enums;
using System;

namespace Paylocity.Web.Models.Entities
{
    public class BenefitAssessmentPerson : EntityBase
    {
        public Guid BenefitAssessmentId { get; set; }
        public BenefitAssessment BenefitAssessment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonType PersonType { get; set; }
    }
}
