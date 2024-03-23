using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Models
{
    internal class Category : IAuditedEntity
    {
        public int Id { get; set; }

        [StringLength(100)]
        public required string Name_en { get; set; }

        [StringLength(100)]
        public required string Name_ar { get; set; }

        [StringLength(1000)]
        public string? Image { get; set; }

        [StringLength(20)]
        public string? Color { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
