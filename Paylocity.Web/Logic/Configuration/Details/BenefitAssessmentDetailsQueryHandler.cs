using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Paylocity.Web.Models.Entities;
using System;
using System.Linq;
using AutoMapper;

namespace Paylocity.Web.Logic.Configuration.Details
{
    public class BenefitAssessmentDetailsQueryHandler
    {

        readonly ApplicationDbContext _applicationDbContext;
        readonly ILogger<BenefitAssessmentDetailsQueryHandler> _logger;
        readonly IMapper _mapper;


        public BenefitAssessmentDetailsQueryHandler(ApplicationDbContext applicationDbContext, ILogger<BenefitAssessmentDetailsQueryHandler> logger,
                                                    IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
            _mapper = mapper;
        }


        public BenefitAssessmentDetailsQueryResult Handle(BenefitAssessmentDetailsQuery benefitAssessmentDetailsQuery)
        {
            BenefitAssessmentDetailsQueryResult benefitAssessmentDetailsQueryResult = new()
            {
                Id = benefitAssessmentDetailsQuery.Id
            };

            BenefitAssessmentConfiguration benefitAssessmentConfiguration = null;


            try
            {
                benefitAssessmentConfiguration = _applicationDbContext.BenefitAssessmentConfigurations.Include(i => i.BenefitAssessmentConfigurationCosts)
                                                                                                      .Include(i => i.BenefitAssessmentConfigurationPayPeriods)
                                                                                                      .FirstOrDefault(fod => fod.Id == benefitAssessmentDetailsQuery.Id);
            }
            catch (Exception ex)
            {
                benefitAssessmentDetailsQueryResult.BenefitAssessmentDetailsQueryResultStatus = BenefitAssessmentDetailsQueryResultStatus.Failure;
                return benefitAssessmentDetailsQueryResult;
            }

            if (benefitAssessmentConfiguration == null)
            {
                benefitAssessmentDetailsQueryResult.BenefitAssessmentDetailsQueryResultStatus = BenefitAssessmentDetailsQueryResultStatus.NotFound;
            }
            else
            {

                try
                {
                    benefitAssessmentDetailsQueryResult.BenefitAssessmentDetailsQueryResultDetails = _mapper.Map<BenefitAssessmentConfiguration, BenefitAssessmentDetailsQueryResultDetails>(benefitAssessmentConfiguration);
                    benefitAssessmentDetailsQueryResult.BenefitAssessmentDetailsQueryResultStatus = BenefitAssessmentDetailsQueryResultStatus.Success;
                }
                catch (Exception ex)
                {
                    benefitAssessmentDetailsQueryResult.BenefitAssessmentDetailsQueryResultStatus = BenefitAssessmentDetailsQueryResultStatus.Failure;
                }
            }

            return benefitAssessmentDetailsQueryResult;
        }
    }
}
