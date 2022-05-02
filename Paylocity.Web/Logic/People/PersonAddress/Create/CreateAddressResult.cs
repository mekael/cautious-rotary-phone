using System;

namespace Paylocity.Web.Logic.People.PersonAddress.Create
{
    public class CreateAddressResult
    {
        public Guid PersonId { get; set; }
        public Guid AddressId { get; set; }
        public CreateAddressResultStatus CreateAddressResultStatus { get; set; }
    }

    public enum CreateAddressResultStatus
    {
        ValidationErrors,
        Failure,
        Success,
    }
}
