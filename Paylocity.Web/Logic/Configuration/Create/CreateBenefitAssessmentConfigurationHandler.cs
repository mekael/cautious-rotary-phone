using AutoMapper;
using Paylocity.Web.Models.Entities;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Paylocity.Web.Logic.Configuration.Create
{
    public class CreateBenefitAssessmentConfigurationHandler
    {

        readonly ApplicationDbContext _applicationDbContext;
        readonly IMapper _mapper;
        readonly ILogger<CreateBenefitAssessmentConfigurationHandler> _logger;

        public CreateBenefitAssessmentConfigurationHandler(ApplicationDbContext applicationDbContext, IMapper mapper, ILogger<CreateBenefitAssessmentConfigurationHandler> logger)
        {
            _applicationDbContext= applicationDbContext;
            _mapper= mapper; 
            _logger= logger;
        }
        public CreateBenefitAssessmentConfigurationResult Handle(CreateBenefitAssessmentConfiguration createBenefitAssessmentConfiguration, string userId)
        {
            CreateBenefitAssessmentConfigurationResult result = new CreateBenefitAssessmentConfigurationResult();

            var validationResults = new CreateBenefitAssessmentConfigurationValidator().Validate(createBenefitAssessmentConfiguration);
            if (!validationResults.IsValid)
            {

            }


            BenefitAssessmentConfiguration benefitAssessmentConfiguration = null;


            try
            {
                var payPeriods = CreatePayPeriods(createBenefitAssessmentConfiguration.StartOfYear, createBenefitAssessmentConfiguration.NumberOfPayPeriodsPerYear, userId);
                benefitAssessmentConfiguration = _mapper.Map<CreateBenefitAssessmentConfiguration, BenefitAssessmentConfiguration>(createBenefitAssessmentConfiguration,
                                                                                                                    opts =>
                                                                                                                    {
                                                                                                                        opts.Items["UserId"] = userId;
                                                                                                                        opts.Items["PayPeriods"] = payPeriods;
                                                                                                                    });
            }
            catch (Exception ex)
            {

            }



            try
            {
                _applicationDbContext.BenefitAssessmentConfigurations.Add(benefitAssessmentConfiguration);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }



            return result;
        }

        List<BenefitAssessmentConfigurationPayPeriod> CreatePayPeriods(DateTime startOfYear, int numberOfPayPeriods, string userId)
        {
            List<BenefitAssessmentConfigurationPayPeriod> payperiods = new List<BenefitAssessmentConfigurationPayPeriod>();

            int daysBetweenPayPeriods = 365 / numberOfPayPeriods;
            for (int i = 1; i <= numberOfPayPeriods; i++)
            {
                payperiods.Add(new BenefitAssessmentConfigurationPayPeriod()
                {
                    PayPeriodStartDate = startOfYear.AddDays((i - 1) * daysBetweenPayPeriods),
                    PayPeriodEndDate = startOfYear.AddDays(i * daysBetweenPayPeriods),
                    LastModifiedByUser = userId,
                    CreatedByUser = userId
                });
            }

            return payperiods;
        }



    }
}
