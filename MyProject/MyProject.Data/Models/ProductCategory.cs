using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Models
{
    internal class ProductCategory : IHaveBusinessId, IAuditedEntity
    {
        public int Id { get; set; }

        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(100)]
        public required string Code { get; set; }

        [StringLength(50)]
        public string? Tag { get; set; }

        [StringLength(50)]
        public string? Color { get; set; }

        [StringLength(1000)]
        public string? Image { get; set; }
        public long? BusinessId { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
