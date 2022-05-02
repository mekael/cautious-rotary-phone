using System.Collections.Generic;
using System;

namespace Paylocity.Web.Models.Entities
{
    public class Employee : EntityBase
    {
        public string HREmployeeId { get; set; }
        
        public ICollection<BenefitAssessment> BenefitAssessments { get; set; }
    }
}
