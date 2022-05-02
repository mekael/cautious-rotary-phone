using System;
using System.Linq;

namespace Paylocity.Web.Logic.People.Create
{
    public class CreatePersonHandler
    {
        readonly ApplicationDbContext _applicationDbContext;


        public CreatePersonResult Handle(CreatePerson createPerson)
        {
            CreatePersonResult createPersonResult = new CreatePersonResult();
            // validate 
            var validationResults = new CreatePersonValidator().Validate(createPerson);

            if (validationResults.IsValid)
            {
                bool? employeeExists = null;

                try
                { 
                 employeeExists = _applicationDbContext.Employees.
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

            }

            return createPersonResult;
        }
    }
}
