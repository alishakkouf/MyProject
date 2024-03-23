using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Business
{
    public class CreateBusinessCommand
    {
        public required string Name { get; set; }

        public required string DomainName { get; set; }

        public required string AdminEmail { get; set; }

        public required string Country { get; set; }

        public required string City { get; set; }

        public string? Description { get; set; }

        public string? Logo { get; set; }

        public string? MobilePhones { get; set; }

        public long Longitude { get; set; }

        public long Latitude { get; set; }

        public bool IsActive { get; set; } = true;

        public string AdminPassword { get; set; }

        public string BusinessEmail { get; set; }

        public string BusinessCountry { get; set; }

        public string BusinessCity { get; set; }

        public string BusinessPhoneCode { get; set; }

        public string BusinessPhone { get; set; }

        public string BusinessOwner { get; set; }

        public string BusinessType { get; set; }

        public required string BusinessCurrency { get; set; }
    }
}
