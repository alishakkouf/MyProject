using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Shared.Enums;

namespace MyProject.Domain.Coupons
{
    public class CouponDomain
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Code { get; set; }

        public string? Tag { get; set; }

        public string? Color { get; set; }

        public string? Image { get; set; }

        public required string Description { get; set; }

        public DateTime EXP { get; set; }

        /// <summary>
        /// visits count
        /// </summary>
        public int NumOfRequests { get; set; }

        public CouponStatus Status { get; set; } = CouponStatus.Active;
    }
}
