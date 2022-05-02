using Paylocity.Web.Models.Enums;
using System;
using System.Collections.Generic;

namespace Paylocity.Web.Logic.Configuration.Details
{
    public class BenefitAssessmentDetailsQueryResult
    {
        public Guid Id { get; set; }
        public BenefitAssessmentDetailsQueryResultDetails BenefitAssessmentDetailsQueryResultDetails { get; set; }
        public BenefitAssessmentDetailsQueryResultStatus BenefitAssessmentDetailsQueryResultStatus { get; set; }
    }

    public enum BenefitAssessmentDetailsQueryResultStatus
    {
        Failure,
        NotFound,
        Success
    }

    public class BenefitAssessmentDetailsQueryResultDetails
    {
        public Guid Id { get; set; }
        public string CreatedByUser { get; set; }
        public string LastModifiedByUser { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public DateTime LastModificationTimestamp { get; set; }
        public DateTime StartOfYear { get; set; }
        public int NumberOfPayPeriodsPerYear { get; set; }
        public float PerPayPeriodSalary { get; set; }

        public DateTime ActiveAsOfDate { get; set; }
        public DateTime? InactiveAsOfDate { get; set; }

        public List<BenefitAssessmentDetailsQueryResultDetailsCostItem> BenefitAssessmentDetailsQueryResultDetailsCostItems { get; set; }
        public List<BenefitAssessmentDetailsQueryResultDetailsPayPeriod> BenefitAssessmentDetailsQueryResultDetailsPayPeriods { get; set; }
    }

    public class BenefitAssessmentDetailsQueryResultDetailsCostItem
    {
        public PersonType PersonType { get; set; }
        public float CostPerYear { get; set; }
        public bool HasNameBasedDiscount { get; set; }
        public float DiscountPercentage { get; set; }
        public NameDiscountMatchingType NameDiscountMatchingType { get; set; }
    }
    public class BenefitAssessmentDetailsQueryResultDetailsPayPeriod 
    {
        public DateTime PayPeriodStartDate { get; set; }
        public DateTime PayPeriodEndDate { get; set; }
        public DateTime PayPeriodPayDate { get; set; }
    }
}
