using System;
using System.Collections.Generic;

namespace Paylocity.Web.Logic.Configuration.Index
{
    public class BenefitAssessmentIndexQueryResult
    {
        public BenefitAssessmentIndexQuery BenefitAssessmentIndexQuery { get; set; }
        public BenefitAssessmentIndexQueryResultStatus BenefitAssessmentIndexQueryResultStatus { get; set; }
        public List<BenefitAssessmentIndexQueryResultItem> BenefitAssessmentIndexQueryResultItems { get; set; }
    }

    public enum BenefitAssessmentIndexQueryResultStatus { 
     Failure,
     Success,
    }

    public class BenefitAssessmentIndexQueryResultItem
    {
        public Guid Id { get; set; }
        public DateTime StartOfYear { get; set; }
        public DateTime ActiveAsOfDate { get; set; }
        public DateTime? InactiveAsOfDate { get; set; }
        public DateTime CreationTimestamp { get; set; } 
        public DateTime LastModificationTimestamp { get; set; } 

    }
}
