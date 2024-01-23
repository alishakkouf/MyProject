using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Models
{
    internal class RedeemLogs : IAuditedEntity, IHaveBusinessId
    {
        public int Id { get; set; }

        public int CouponId { get; set; }

        public int ClientId { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool? IsDeleted { get; set; } = false;

        public int? BusinessId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual required UserAccount Client { get; set; }

        [ForeignKey(nameof(CouponId))]
        public virtual required Coupon Coupon { get; set; }
    }
}
