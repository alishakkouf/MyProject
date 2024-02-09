using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Localization;
using MyProject.Data.Models;
using MyProject.Domain.Coupons;
using MyProject.Shared;

namespace MyProject.Data.Providers.CouponFolder
{
    internal class CouponProvider : GenericProvider<Coupon>, ICouponProvider
    {
        private readonly IStringLocalizer _localizer;
        private readonly IMapper _mapper;
        public CouponProvider(IStringLocalizerFactory factory, MyProjectDbContext dbContext,
            IMapper mapper)
        {
            _localizer = factory.Create(typeof(CommonResource)); 
             DbContext = dbContext;
            _mapper = mapper;
         }

        public async Task<CouponDomain> CreateAsync(CreateCouponCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CouponDomain>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UpdateCouponCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
