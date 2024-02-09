using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Coupons
{
    public interface ICouponProvider
    {
        Task<List<CouponDomain>> GetAllAsync();

        Task<CouponDomain> CreateAsync(CreateCouponCommand command);

        Task UpdateAsync(UpdateCouponCommand command);

        Task DeleteAsync(int id);
    }
}
