using Microsoft.AspNetCore.Mvc;
using Paylocity.Web.Logic.Configuration.Create;
using Paylocity.Web.Logic.Configuration.Index;

namespace Paylocity.Web.Controllers
{
    public class AssessmentConfigurationController : Controller
    {
        CreateBenefitAssessmentConfigurationHandler _createBenefitAssessmentConfigurationHandler;
        BenefitAssessmentIndexQueryHandler _benefitAssessmentIndexQueryHandler;
        public AssessmentConfigurationController(CreateBenefitAssessmentConfigurationHandler createBenefitAssessmentConfigurationHandler,
                                                 BenefitAssessmentIndexQueryHandler benefitAssessmentIndexQueryHandler) 
        {
            _createBenefitAssessmentConfigurationHandler = createBenefitAssessmentConfigurationHandler;
            _benefitAssessmentIndexQueryHandler = benefitAssessmentIndexQueryHandler;
        }


        public IActionResult Index([FromQuery] BenefitAssessmentIndexQuery benefitAssessmentIndexQuery)
        {

            var queryResult = _benefitAssessmentIndexQueryHandler.Handle(benefitAssessmentIndexQuery);
            if(queryResult.BenefitAssessmentIndexQueryResultStatus != BenefitAssessmentIndexQueryResultStatus.Success)
            {
                return StatusCode(500);
            }

            return View(queryResult);
        }

        [HttpGet]
        public IActionResult Create() {

            return View(new CreateBenefitAssessmentConfiguration());
        
        }

        [HttpPost]
        public IActionResult Create(CreateBenefitAssessmentConfiguration createBenefitAssessmentConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return View(createBenefitAssessmentConfiguration);
            }

            var result = _createBenefitAssessmentConfigurationHandler.Handle(createBenefitAssessmentConfiguration, User.Identity.Name);
            return View(createBenefitAssessmentConfiguration);
        }
    }
}
