﻿using Paylocity.Web.Models.Enums;
using System;

namespace Paylocity.Web.Logic.People.PersonAddress.Update
{
    public class UpdateAddress
    {
        public Guid PersonId { get; set; }
        public Guid AddressId { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public AddressType AddressType { get; set; }
    }
}
