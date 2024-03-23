using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Shared.Enums;
using MyProject.Shared.RequestDtos;

namespace MyProject.Domain.Coupons
{
    public class GetAllCouponsQuery : PagedAndSortedResultRequestDto
    {
        public string? Keyword { get; set; }

        public int? NumOfRequests { get; set; }

        public CouponStatus? Status { get; set; } = CouponStatus.Active;

        public DateTime? MinEXP { get; set; }

        public DateTime? MaxEXP { get; set; }

        public bool IsFromClient { get; set; }
    }
}
