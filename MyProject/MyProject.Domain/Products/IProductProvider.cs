using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Shared.ResultDtos;

namespace MyProject.Domain.Products
{
    public interface IProductProvider
    {
        Task<PagedResultDto<ProductDomain>> GetAllAsync(ProductListQuery query);

        Task<ProductDomain> CreateAsync(CreateProductCommand command);

        Task<ProductDomain> UpdateAsync(UpdateProductCommand command);

        Task<bool> DeleteAsync(int id);
    }
}
