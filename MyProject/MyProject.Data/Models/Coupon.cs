using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Shared.Enums;

namespace MyProject.Data.Models
{
    internal class Coupon : IHaveBusinessId, IAuditedEntity
    {
        public long Id { get; set; }

        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(100)]
        public required string Code { get; set; }

        [StringLength(50)]
        public string? Tag { get; set; }

        [StringLength(20)]
        public string? Color { get; set; }

        [StringLength(1000)]
        public string? Image { get; set; }

        [StringLength(10000)]
        public required string Description { get; set; }

        public DateTime? EXP { get; set; }

        /// <summary>
        /// visits count
        /// </summary>
        public required int NumOfStamps { get; set; }

        public CouponStatus Status { get; set; } = CouponStatus.Active;

        public long? BusinessId { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
