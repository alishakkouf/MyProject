namespace MyProject.Areas.Admin.Dtos
{
    public class BusinessDto
    {
        public long Id { get; set; }

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

        public string BusinessCurrency { get; set; }
    }
}
