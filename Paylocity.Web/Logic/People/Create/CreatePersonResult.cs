using System;

namespace Paylocity.Web.Logic.People.Create
{
    public class CreatePersonResult
    {
        public Guid PersonId { get; set; }
        public CreatePersonResultStatus CreatePersonResultStatus { get; set; }
    }

    public enum CreatePersonResultStatus
    {
        ValidationError,
        Success,
        Failure
    }
}
