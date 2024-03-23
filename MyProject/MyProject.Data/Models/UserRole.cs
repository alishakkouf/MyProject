using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MyProject.Data.Models
{
    public class UserRole : IdentityRole<long>, IAuditedEntity, IHaveBusinessId
    {
        UserRole() : base() { }

        [StringLength(1000)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool? IsDeleted { get; set; } = false;

        public long? BusinessId { get; set; }

        public UserRole(string roleName) : base(roleName)
        {
        }

        internal virtual ICollection<UserAccount> UserAccounts { get; set; } = new HashSet<UserAccount>();

        public virtual ICollection<IdentityRoleClaim<long>> Claims { get; set; } = new HashSet<IdentityRoleClaim<long>>();
    }
}
