using System;
using System.Collections.Generic;

namespace Paylocity.Web.Models.Entities
{
    public class BenefitAssessment : EntityBase
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid BenefitAssessmentConfigurationId { get; set; }
        public BenefitAssessmentConfiguration BenefitAssessmentConfiguration { get; set; }

        public ICollection<BenefitAssessmentPerson> BenefitAssessmentPeople { get; set; }

    }
}
