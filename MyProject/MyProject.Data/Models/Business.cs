using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Shared.Enums;
using Newtonsoft.Json;

namespace MyProject.Data.Models
{
    internal class Business : IAuditedEntity
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

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        [StringLength(50)]
        public string? EncryptedId { get; set; }

        [StringLength(50)]
        public string? Token { get; set; }
    }
}
