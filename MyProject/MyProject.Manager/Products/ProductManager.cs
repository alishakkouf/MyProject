using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MyProject.Domain.Products;
using MyProject.Shared;
using MyProject.Shared.ResultDtos;

namespace MyProject.Manager.Products
{
    internal class ProductManager(IProductProvider provider, IStringLocalizerFactory factory) : IProductManager
    {
        private readonly IStringLocalizer _localizer = factory.Create(typeof(CommonResource));
        private readonly IProductProvider _productProvider = provider;

        public async Task<ProductDomain> CreateAsync(CreateProductCommand command)
        {
            return await _productProvider.CreateAsync(command);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _productProvider.DeleteAsync(id);
        }

        public async Task<PagedResultDto<ProductDomain>> GetAllAsync(ProductListQuery query)
        {
            return await _productProvider.GetAllAsync(query);
        }

        public async Task<ProductDomain> UpdateAsync(UpdateProductCommand command)
        {
            return await _productProvider.UpdateAsync(command);
        }
    }
}
