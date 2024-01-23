using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Models
{
    internal class UserCoupon
    {
        public int Id { get; set; }

        public int CouponId { get; set; }

        public int ClientId { get; set; }

        public bool IsRedeemed { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual required UserAccount Client { get; set; }

        [ForeignKey(nameof(CouponId))]
        public virtual required Coupon Coupon { get; set; }
    }
}
