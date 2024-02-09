using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MyProject.Domain.Coupons;
using MyProject.Shared;

namespace MyProject.Manager.Coupons
{
    internal class CouponManager(ICouponProvider couponProvider, IStringLocalizerFactory factory) : ICouponManager
    {
        private readonly ICouponProvider _couponProvider = couponProvider;
        private readonly IStringLocalizer _localizer = factory.Create(typeof(CommonResource));
        

        public async Task<CouponDomain> CreateAsync(CreateCouponCommand command)
        {
            return await _couponProvider.CreateAsync(command);
        }

        public async Task DeleteAsync(int id)
        {
            await _couponProvider.DeleteAsync(id);
        }

        public async Task<List<CouponDomain>> GetAllAsync()
        {
            return await _couponProvider.GetAllAsync();
        }

        public async Task UpdateAsync(UpdateCouponCommand command)
        {
            await _couponProvider.UpdateAsync(command);
        }
    }
}
