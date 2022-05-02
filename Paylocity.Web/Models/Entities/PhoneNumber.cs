using System;
using System.Web;
using Paylocity.Web.Models.Enums;

namespace Paylocity.Web.Models.Entities
{
    public class PhoneNumber : EntityBase
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public string AreaCode { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
        public DateTime ActiveAsOfDate { get; set; } = DateTime.Now;
        public DateTime? InactiveAsOfDate { get; set; }
    }
}
