using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Shared.Enums;

namespace MyProject.Data.Models
{
    internal class UserCoupon : IHaveBusinessId, IAuditedEntity
    {
        public long Id { get; set; }

        public long CouponId { get; set; }

        public long ClientId { get; set; }

        public CouponStatus Status { get; set; } = CouponStatus.Active;

        /// <summary>
        /// history for the coupon
        /// </summary>
        public int NumOfRequests { get; set; }

        public DateTime? EXP { get; set; }

        public long? BusinessId { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual required UserAccount Client { get; set; }

        [ForeignKey(nameof(CouponId))]
        public virtual required Coupon Coupon { get; set; }
    }
}
