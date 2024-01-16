using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Models
{
    internal class Setting : IAuditedEntity, IHaveBusinessId
    {
        public long Id { get; set; }

        [Required]
        [StringLength(1000)]
        public required string Name { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        public string Value { get; set; }

        /// <summary>
        /// If userId is null then this setting is an application setting, else it's user setting
        /// </summary>
        public long? UserId { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool? IsDeleted { get; set; } = false;

        public int? BusinessId { get; set; }
    }
}
