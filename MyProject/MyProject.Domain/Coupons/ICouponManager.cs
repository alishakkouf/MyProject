using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Coupons
{
    public interface ICouponManager
    {
        Task<CouponListResult> GetAllAsync(GetAllCouponsQuery query);

        Task<CouponDomain> CreateAsync(CreateCouponCommand command);

        Task UpdateAsync(UpdateCouponCommand command);

        Task DeleteAsync(long id);

        Task<byte[]> GenerateQRAsync(CreateQRCommand command);

        Task<CouponDomain> GetAsync(long id, bool isFromClient);
    }
}
