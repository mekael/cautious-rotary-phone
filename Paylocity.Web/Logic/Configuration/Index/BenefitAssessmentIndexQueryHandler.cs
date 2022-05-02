using AutoMapper;
using Microsoft.Extensions.Logging;
using Paylocity.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paylocity.Web.Logic.Configuration.Index
{
    public class BenefitAssessmentIndexQueryHandler
    {
        readonly ApplicationDbContext _applicationDbContext;
        readonly IMapper _mapper;
        readonly ILogger<BenefitAssessmentIndexQueryHandler> _logger;

        public BenefitAssessmentIndexQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper, ILogger<BenefitAssessmentIndexQueryHandler> logger)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public BenefitAssessmentIndexQueryResult Handle(BenefitAssessmentIndexQuery benefitAssessmentIndexQuery)
        {
            benefitAssessmentIndexQuery.Validate();
            var result = new BenefitAssessmentIndexQueryResult() { 
                                                                    BenefitAssessmentIndexQuery = benefitAssessmentIndexQuery
                                                                  };

            int itemsToSkip = benefitAssessmentIndexQuery.NumberOfItemsPerPage * (benefitAssessmentIndexQuery.PageNumber - 1);
            List<BenefitAssessmentConfiguration> configs = null;

            //TODO: add in logic for better filtering/sorting. 


            try
            {
                configs = _applicationDbContext.BenefitAssessmentConfigurations.OrderByDescending(obd => obd.CreationTimestamp).Skip(itemsToSkip).Take(benefitAssessmentIndexQuery.NumberOfItemsPerPage).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while querying for assessment configs: {ex}", ex.ToString());
                return result;
            }

            //TODO: Add in logic which automatically returns you to the last page if you go too far.


            try
            {
                result.BenefitAssessmentIndexQueryResultItems = _mapper.Map<List<BenefitAssessmentConfiguration>, List<BenefitAssessmentIndexQueryResultItem>>(configs);
                result.BenefitAssessmentIndexQueryResultStatus = BenefitAssessmentIndexQueryResultStatus.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to map assessment configs onto listing items : {ex}", ex.ToString());

            }

            return result;

        }
    }
}
