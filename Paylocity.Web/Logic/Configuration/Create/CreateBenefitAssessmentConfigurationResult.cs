using System;

namespace Paylocity.Web.Logic.Configuration.Create
{
    public class CreateBenefitAssessmentConfigurationResult
    {
        public Guid Id { get; set; }
        public CreateBenefitAssessmentConfigurationResultStatus CreateBenefitAssessmentConfigurationResultStatus { get; set; }
    }

    public enum CreateBenefitAssessmentConfigurationResultStatus
    {

        ValidationFailure,
        SqlFailure,
        Success
    }
}
