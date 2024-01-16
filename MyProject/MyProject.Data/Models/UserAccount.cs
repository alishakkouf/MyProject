using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyProject.Shared.Enums;

namespace MyProject.Data.Models
{
    public class UserAccount : IdentityUser<long>, IAuditedEntity, IHaveBusinessId
    {
        
        [StringLength(100)]
        public required string FirstName { get; set; }
               
        [StringLength(100)]
        public required string LastName { get; set; }
                
        [StringLength(20)]
        public override required string PhoneNumber { get; set; }

        [StringLength(10)]
        public string PhoneCountryCode { get; set; }

        [StringLength(1000)]
        public string ImageRelativePath { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender? Gender { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool? IsDeleted { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public DateTime? LastLoginTime { get; set; }

        [StringLength(10)]
        public string ConfirmationCode { get; set; }

        public bool IsCodeConfirmed { get; set; }

        public DateTime? ConfirmationCodeEndDate { get; set; }

        public int? RetryCount { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        public int? BusinessId { get; set; }

        internal virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

    }
}

