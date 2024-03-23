using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Domain.Products;
using MyProject.Shared.ResultDtos;

namespace MyProject.Domain.Coupons
{
    public class CouponListResult : PagedResultDto<CouponDomain>
    {
        public decimal MaxQuantity { get; set; }

        public CouponListResult(int totalCount, IReadOnlyList<CouponDomain> items)
            : base(totalCount, items)
        {

        }
    }
}