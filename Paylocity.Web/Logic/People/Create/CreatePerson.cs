using Paylocity.Web.Models.Enums;
using System;

namespace Paylocity.Web.Logic.People.Create
{
    public class CreatePerson
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string GovernmentId { get; set; }
        public PersonType PersonType { get; set; }

    }
}
