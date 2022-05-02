using AutoMapper;
using Microsoft.Extensions.Logging;
using Paylocity.Web.Logic.People.PersonAddress.Create;
using Paylocity.Web.Models.Entities;
using System;
using System.Linq;

namespace Paylocity.Web.Logic.People.PersonAddress.Update
{
    public class UpdateAddressHandler
    {


        readonly ApplicationDbContext _applicationDbContext;
        readonly IMapper _mapper;
        readonly ILogger<UpdateAddressHandler> _logger;

        public UpdateAddressHandler(ApplicationDbContext applicationDbContext, IMapper mapper, ILogger<UpdateAddressHandler> logger)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        // this functionality is not inherently safe 
        // in that you can have a race condition where two address updates are processed at the same time for a given person record.
        public UpdateAddressResult Handle(UpdateAddress updateAddress, string userId)
        {
            UpdateAddressResult updateAddressResult = new UpdateAddressResult()
            {
                PersonID = updateAddress.PersonId,
                PreviousAddressId = updateAddress.AddressId
            };

            // validation. 

            var validationResults = new UpdateAddressValidator().Validate(updateAddress);
            if (validationResults.IsValid)
            {
                // obtain the previous address, we are going to be double checking 
                Address previousAddress = null;
                try
                {
                    previousAddress = _applicationDbContext.Addresses.FirstOrDefault(w => w.PersonId == updateAddress.PersonId && w.Id == updateAddress.AddressId);
                }
                catch (Exception ex)
                {
                    updateAddressResult.UpdateAddressResultStatus = UpdateAddressResultStatus.Failure;
                    return updateAddressResult;
                }


                if (previousAddress == null)
                {
                    updateAddressResult.UpdateAddressResultStatus = UpdateAddressResultStatus.NotFound;
                }
                else
                {
                    var newAddress = _mapper.Map<UpdateAddress, Address>(updateAddress, opts=> opts.Items["UserId"]=userId);
                    previousAddress.InactiveAsOfDate = DateTime.Now;
                    previousAddress.LastModificationTimestamp = DateTime.Now;
                    previousAddress.LastModifiedByUser = userId;

                    try {
                        _applicationDbContext.Entry(previousAddress).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _applicationDbContext.Addresses.Add(newAddress);
                        _applicationDbContext.SaveChanges();
                        updateAddressResult.UpdateAddressResultStatus = UpdateAddressResultStatus.Success;
                    }
                    catch(Exception ex)
                    {
                        updateAddressResult.UpdateAddressResultStatus = UpdateAddressResultStatus.Failure;
                    }

                }
            }
            else
            {
                updateAddressResult.UpdateAddressResultStatus = UpdateAddressResultStatus.ValidationError;
            }
            return updateAddressResult;

        }
    }
}
