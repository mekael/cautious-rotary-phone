using System;

namespace Paylocity.Web.Logic.People.PersonAddress.Update
{
    public class UpdateAddressResult
    {
        public Guid PersonID { get; set; }
        public Guid PreviousAddressId { get; set; }
        public Guid NewAddressId { get; set; }
        public UpdateAddressResultStatus UpdateAddressResultStatus { get; set; }
    }

    public enum UpdateAddressResultStatus
    {
        ValidationError,
        Failure,
        NotFound,
        Success
    }
}
