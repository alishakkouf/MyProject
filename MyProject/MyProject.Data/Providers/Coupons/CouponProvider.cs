using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using MyProject.Data.Models;
using MyProject.Domain.Coupons;
using MyProject.Domain.Products;
using MyProject.Shared;
using MyProject.Shared.Enums;
using MyProject.Shared.Exceptions;

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
            var toBeAdded = _mapper.Map<Coupon>(command);

            await DbContext.Coupons.AddAsync(toBeAdded);
            await DbContext.SaveChangesAsync();

            return _mapper.Map<CouponDomain>(toBeAdded);
        }

        public async Task DeleteAsync(long id)
        {
            var toBeDeleted = await ActiveDbSet.FirstOrDefaultAsync(x=>x.Id.Equals(id))
                            ?? throw new EntityNotFoundException(nameof(Product), id.ToString());

            toBeDeleted.IsDeleted = true;

            await DbContext.SaveChangesAsync();
        }

        public async Task<CouponDomain> GetAsync(long id, bool isFromClient)
        {
            var coupon = isFromClient ? await ActiveDbSet.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id)
                                      : await ActiveDbSet.FirstOrDefaultAsync(x => x.Id == id)
                                      ?? throw new EntityNotFoundException(nameof(Coupon), id.ToString());

            return _mapper.Map<CouponDomain>(coupon);
        }

        public async Task<CouponListResult> GetAllAsync(GetAllCouponsQuery query)
        {
            var data = CreateFilteredQuery(query);
            var totalCount = await data.CountAsync();

            data = ApplySorting(data, query);

            if (query.IsPaginated())
                data = ApplyPaging(data, query);

            var list = _mapper.Map<List<CouponDomain>>(await data.ToListAsync());

            return new CouponListResult(totalCount, list);
        }

        public async Task UpdateAsync(UpdateCouponCommand command)
        {
            var coupon = await ActiveDbSet.FirstOrDefaultAsync(x => x.Id == command.Id)
                ?? throw new EntityNotFoundException(nameof(Coupon), command.Id.ToString());

            _mapper.Map(command, coupon);

            await DbContext.SaveChangesAsync();

            _mapper.Map<CouponDomain>(coupon);
        }

        private IQueryable<Coupon> CreateFilteredQuery(GetAllCouponsQuery query)
        {
            IQueryable<Coupon> data;

            if (query.IsFromClient)
                data = ActiveDbSet.IgnoreQueryFilters().AsNoTracking();
            else
                data = ActiveDbSet.AsNoTracking();

            if (!string.IsNullOrEmpty(query.Keyword))
                data = data.Where(x => x.Name.Contains(query.Keyword) ||
                    x.Code.Contains(query.Keyword) ||
                    x.Tag.Contains(query.Keyword));

            if (query.MinEXP.HasValue)
                data = data.Where(x => x.EXP >= query.MinEXP );

            if (query.MaxEXP.HasValue)
                data = data.Where(x => x.EXP <= query.MaxEXP);

            if (query.Status.HasValue)
                data = data.Where(x => x.Status == query.Status);

            if (query.NumOfRequests.HasValue)
                data = data.Where(x => x.NumOfStamps == query.NumOfRequests);

            return data;
        }

        private static IQueryable<Coupon> ApplySorting(IQueryable<Coupon> query,
            GetAllCouponsQuery request)
        {
            if (string.IsNullOrEmpty(request.SortingField))
                return request.SortingDir == SortingDirection.Desc ?
                    query.OrderByDescending(x => x.ModifiedAt ?? x.CreatedAt) :
                    query.OrderBy(x => x.ModifiedAt ?? x.CreatedAt);

            var sortDir = request.SortingDir == SortingDirection.Desc ? " DESC" : " ASC";
            var sortField = nameof(Coupon.Name) + sortDir;

            if (request.SortingField.Equals(nameof(Coupon.Id), StringComparison.InvariantCultureIgnoreCase))
                sortField = nameof(Coupon.Id) + sortDir;

            if (request.SortingField.Equals(nameof(Coupon.NumOfStamps), StringComparison.InvariantCultureIgnoreCase))
                sortField = nameof(Coupon.NumOfStamps) + sortDir;

            else if (request.SortingField.Equals(nameof(Coupon.Tag), StringComparison.InvariantCultureIgnoreCase))
                sortField = nameof(Coupon.Tag) + sortDir;

            else if (request.SortingField.Equals(nameof(Coupon.EXP), StringComparison.InvariantCultureIgnoreCase))
                sortField = nameof(Coupon.EXP) + sortDir;

            return query.OrderBy(sortField);
        }

        private static IQueryable<Coupon> ApplyPaging(IQueryable<Coupon> query, GetAllCouponsQuery request)
        {
            var take = request.PageSize ?? Constants.DefaultPageSize;
            var skip = ((request.PageIndex ?? Constants.DefaultPageIndex) - 1) * take;

            return query.Skip(skip).Take(take);
        }

    }
}
