using AutoMapper;
using Microsoft.Extensions.Logging;
using Paylocity.Web.Models.Entities;
using System;

namespace Paylocity.Web.Logic.People.PersonAddress.Create
{
    public class CreateAddressHandler
    {
        readonly ApplicationDbContext _applicationDbContext;
        readonly IMapper _mapper;
        readonly ILogger<CreateAddressHandler> _logger;

        public CreateAddressHandler(ApplicationDbContext applicationDbContext, IMapper mapper, ILogger<CreateAddressHandler> logger)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public CreateAddressResult Handle(CreateAddress createAddress, string userId)
        {
            CreateAddressResult createAddressResult = new CreateAddressResult();

            var validationResults = new CreateAddressValidator().Validate(createAddress);
            if (!validationResults.IsValid)
            {
                createAddressResult.CreateAddressResultStatus = CreateAddressResultStatus.ValidationErrors;
            }
            else
            {
                Address address = null;

                try
                {
                    address = _mapper.Map<CreateAddress, Address>(createAddress, opts => opts.Items["UserId"] = userId);
                }
                catch (Exception ex)
                {
                    createAddressResult.CreateAddressResultStatus = CreateAddressResultStatus.Failure;
                }

                if (address != null)
                {
                    try
                    {
                        _applicationDbContext.Addresses.Add(address);
                        _applicationDbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        createAddressResult.CreateAddressResultStatus = CreateAddressResultStatus.Failure;
                    }
                }
            }
            return createAddressResult;
        }
    }
}
