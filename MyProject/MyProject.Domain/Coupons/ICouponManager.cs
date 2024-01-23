using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Coupons
{
    public interface ICouponManager
    {
        Task<List<CouponDomain>> GetAllAsync();

        Task CreateAsync(CreateCouponCommand command);

        Task UpdateAsync(UpdateCouponCommand command);
    }
}
