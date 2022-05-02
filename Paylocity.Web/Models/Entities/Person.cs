using Paylocity.Web.Models.Enums;
using System;
using System.Collections.Generic;

namespace Paylocity.Web.Models.Entities
{
    public class Person : EntityBase
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
      
        public ICollection<PersonDemographic> PersonDemographics { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public DateTime ActiveAsOfDate { get; set; } = DateTime.Now;
        public DateTime? InactiveAsOfDate { get; set; }

        public PersonType PersonType { get; set; }
        
    }
}
