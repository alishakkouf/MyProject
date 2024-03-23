using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Models
{
    internal class FeaturedCoupons
    {
        public long Id { get; set; }

        public long CouponId { get; set; }

        public long ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual required UserAccount Client { get; set; }

        [ForeignKey(nameof(CouponId))]
        public virtual required Coupon Coupon { get; set; }
    }
}
