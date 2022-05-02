using AutoMapper;
using Paylocity.Web.Logic.Configuration.Create;
using Paylocity.Web.Logic.Configuration.Details;
using Paylocity.Web.Logic.Configuration.Index;
using Paylocity.Web.Models.Entities;

namespace Paylocity.Web.Logic.Configuration
{
    public class ConfigurationMappingProfile : Profile
    {
        public ConfigurationMappingProfile()
        {

            CreateMap<CreateBenefitAssessmentConfiguration, BenefitAssessmentConfiguration>()
                     .ForMember(dst => dst.CreatedByUser, src => src.MapFrom((a, b, c, d) => d.Items["UserId"]))
                     .ForMember(dst => dst.LastModifiedByUser, src => src.MapFrom((a, b, c, d) => d.Items["UserId"]))
                     .ForMember(dst => dst.BenefitAssessmentConfigurationCosts, src => src.MapFrom(mf => mf.CreateBenefitAssessmentConfigurationPersonCosts))
                     .ForMember(dst=> dst.BenefitAssessmentConfigurationPayPeriods, src => src.MapFrom((a, b, c, d) => d.Items["PayPeriods"]))
                ;

            CreateMap<CreateBenefitAssessmentConfigurationPersonCost, BenefitAssessmentConfigurationCost>()
                     .ForMember(dst => dst.CreatedByUser, src => src.MapFrom((a, b, c, d) => d.Items["UserId"]))
                     .ForMember(dst => dst.LastModifiedByUser, src => src.MapFrom((a, b, c, d) => d.Items["UserId"]))
                     ;
            CreateMap<BenefitAssessmentConfiguration,BenefitAssessmentIndexQueryResultItem>();

            CreateMap<BenefitAssessmentConfiguration, BenefitAssessmentDetailsQueryResultDetails>();
            CreateMap<BenefitAssessmentConfigurationCost, BenefitAssessmentDetailsQueryResultDetailsCostItem>();
            CreateMap<BenefitAssessmentConfigurationPayPeriod, BenefitAssessmentDetailsQueryResultDetailsPayPeriod>();



        }
    }
}
