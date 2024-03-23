using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Business
{
    public class UpdateBusinessCommand
    {
        public long Id { get; set; }

        [StringLength(200)]
        public required string Name { get; set; }

        [StringLength(1000)]
        public required string DomainName { get; set; }

        [StringLength(500)]
        public required string AdminEmail { get; set; }

        [StringLength(50)]
        public required string Country { get; set; }

        [StringLength(50)]
        public required string City { get; set; }

        [StringLength(10000)]
        public string? Description { get; set; }

        [StringLength(1000)]
        public string? Logo { get; set; }

        [StringLength(500)]
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

        public string BusinessCurrency { get; set; }
    }
}
