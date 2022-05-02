using Paylocity.Web.Models.Enums;
using System;

namespace Paylocity.Web.Models.Entities
{
    public class Address : EntityBase
    {   
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public AddressType AddressType { get; set; }
        public DateTime ActiveAsOfDate { get; set; } = DateTime.Now;
        public DateTime? InactiveAsOfDate { get; set; }
    }
}
