using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Shared.Enums;

namespace MyProject.Data.Models
{
    internal class UserCouponStamp : IAuditedEntity
    {
        public long Id { get; set; }

        public long UserCouponId { get; set; }

        [StringLength(1000)]
        public required string QrCode { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(UserCouponId))]
        public virtual required UserCoupon UserCoupon { get; set; }

    }
}
