using AutoMapper;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using MyProject.Data.Models;
using MyProject.Domain.Products;
using MyProject.Shared;
using MyProject.Shared.Enums;
using MyProject.Shared.Exceptions;
using MyProject.Shared.ResultDtos;

namespace MyProject.Data.Providers.ProductFolder
{
    internal class ProductProvider : GenericProvider<Product>, IProductProvider
    {
        private readonly IStringLocalizer _localizer;
        private readonly IMapper _mapper;
        public ProductProvider(IStringLocalizerFactory factory, MyProjectDbContext dbContext,
            IMapper mapper)
        {
            _localizer = factory.Create(typeof(CommonResource));
            DbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDomain> CreateAsync(CreateProductCommand command)
        {
            var newProduct = _mapper.Map<Product>(command);

            await DbContext.Products.AddAsync(newProduct);
            await DbContext.SaveChangesAsync();

            return _mapper.Map<ProductDomain>(newProduct);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var prodct = await ActiveDbSet.FirstOrDefaultAsync(x => x.Id == id)
                         ?? throw new EntityNotFoundException(nameof(Product), id.ToString());

            await SoftDeleteAsync(prodct);

            return true;
        }

        public async Task<PagedResultDto<ProductDomain>> GetAllAsync(ProductListQuery query)
        {
            var data = CreateFilteredQuery(query);
            var totalCount = await data.CountAsync();

            data = ApplySorting(data, query);

            if (query.IsPaginated())
                data = ApplyPaging(data, query);

            var list = _mapper.Map<List<ProductDomain>>(await data.ToListAsync());
            return new PagedResultDto<ProductDomain>(totalCount, list);
        }

        public async Task<ProductDomain> UpdateAsync(UpdateProductCommand command)
        {
            var product = await ActiveDbSet.FirstOrDefaultAsync(x => x.Id == command.Id)
                          ?? throw new EntityNotFoundException(nameof(Product), command.Id.ToString());

            _mapper.Map(command, product);

            await DbContext.SaveChangesAsync();

            return _mapper.Map<ProductDomain>(product);
        }

        private IQueryable<Product> CreateFilteredQuery(ProductListQuery request)
        {
            var query = ActiveDbSet.AsNoTracking();

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword) ||
                                         x.Code.Contains(request.Keyword));

            return query;
        }

        private static IQueryable<Product> ApplySorting(IQueryable<Product> query,
            ProductListQuery request)
        {
            if (string.IsNullOrEmpty(request.SortingField))
                return request.SortingDir == SortingDirection.Desc ?
                    query.OrderByDescending(x => x.ModifiedAt ?? x.CreatedAt) :
                    query.OrderBy(x => x.ModifiedAt ?? x.CreatedAt);

            var sortDir = request.SortingDir == SortingDirection.Desc ? " DESC" : " ASC";
            var sortField = nameof(Product.Name) + sortDir;

            if (request.SortingField.Equals(nameof(Product.Code), StringComparison.InvariantCultureIgnoreCase))
                sortField = $"{nameof(Product.Code) + sortDir}";

            return query.OrderBy(sortField);
        }

        private static IQueryable<Product> ApplyPaging(IQueryable<Product> query, ProductListQuery request)
        {
            var take = request.PageSize ?? Constants.DefaultPageSize;
            var skip = ((request.PageIndex ?? Constants.DefaultPageIndex) - 1) * take;

            return query.Skip(skip).Take(take);
        }
    }
}
