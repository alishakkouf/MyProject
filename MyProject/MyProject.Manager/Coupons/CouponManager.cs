using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MyProject.Domain.Coupons;
using MyProject.Shared;
using MyProject.Manager.Helpers;
using System.Collections;

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

        public async Task DeleteAsync(long id)
        {
            await _couponProvider.DeleteAsync(id);
        }

        public async Task<byte[]> GenerateQRAsync(CreateQRCommand couponId)
        {
            return await Task.FromResult(QR_Generator.GenerateQRCode(couponId));
        }

        public async Task<CouponListResult> GetAllAsync(GetAllCouponsQuery query)
        {
            return await _couponProvider.GetAllAsync(query);
        }

        public async Task UpdateAsync(UpdateCouponCommand command)
        {
            await _couponProvider.UpdateAsync(command);
        }

        public async Task<CouponDomain> GetAsync(long id, bool isFromClient) 
        {
            return await _couponProvider.GetAsync(id, isFromClient);
        }
    }
}
