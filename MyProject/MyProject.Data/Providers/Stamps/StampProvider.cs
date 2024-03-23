using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Localization;
using MyProject.Data.Models;
using MyProject.Domain.Products;
using MyProject.Domain.Stamps;
using MyProject.Shared;

namespace MyProject.Data.Providers.Stamps
{
    internal class StampProvider : GenericProvider<UserCouponStamp>, IStampProvider
    {
        private readonly IStringLocalizer _localizer;
        private readonly IMapper _mapper;
        public StampProvider(IStringLocalizerFactory factory, MyProjectDbContext dbContext,
            IMapper mapper)
        {
            _localizer = factory.Create(typeof(CommonResource));
            DbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddStampAsync(long couponId, string qrCode, long clientId)
        {
            var userCoupon = await DbContext.UserCoupons.FirstOrDefaultAsync(x=> x.CouponId == couponId &&
                                                                                 x.ClientId == clientId);
            var toBeInserted = new UserCouponStamp()
            {
                QrCode = qrCode,
                UserCoupon = userCoupon,
                UserCouponId = userCoupon.Id
            };

            await DbContext.UserCouponStamps.AddAsync(toBeInserted);
            await DbContext.SaveChangesAsync();
        }
    }
}
