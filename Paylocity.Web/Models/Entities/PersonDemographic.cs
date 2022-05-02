using System;

namespace Paylocity.Web.Models.Entities
{
    public class PersonDemographic : EntityBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string GovernmentId { get; set; }
        public DateTime ActiveAsOfDate { get; set; } = DateTime.Now;
        public DateTime? InactiveAsOfDate { get; set; }


    }
}
