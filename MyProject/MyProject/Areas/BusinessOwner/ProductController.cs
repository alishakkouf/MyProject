using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Areas.BusinessOwner.ProductsDtos;
using MyProject.Domain.Products;
using MyProject.Shared;
using MyProject.Shared.ResultDtos;

namespace MyProject.Areas.BusinessOwner
{
    public class ProductController(IStringLocalizerFactory factory,
           ILogger<ProductController> logger,
           IProductManager productManager, IMapper Mapper) : BaseBusinessController(factory)
    {
        private readonly ILogger<ProductController> _logger = logger ?? throw new ArgumentNullException(nameof(factory));
        private readonly IMapper _mapper;
        private readonly IProductManager _productManager = productManager;

        /// <summary>
        /// Get all Products
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ProductDto>>> GetAllAsync(ProductListRequestDto query)
        {
            _logger.LogInformation($"Getting list of admins(owner of businesses) via {nameof(GetAllAsync)} API");

            var data = await _productManager.GetAllAsync(_mapper.Map<ProductListQuery>(query));

            return Ok(_mapper.Map<PagedResultDto<ProductDto>>(data));
        }

        /// <summary>
        /// Create new Product
        /// </summary>
        [HttpPost("Create")]
        public async Task<ActionResult> CreateAsync(CreateProductRequestDto requestDto)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(ProductController));

            await _productManager.CreateAsync(_mapper.Map<CreateProductCommand>(requestDto));

            return Ok();
        }

        /// <summary>
        /// Update existed Coupon
        /// </summary>
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateAsync(UpdateProductRequestDto requestDto)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(ProductController));

            await _productManager.UpdateAsync(_mapper.Map<UpdateProductCommand>(requestDto));

            return Ok();
        }

        /// <summary>
        /// Delete Coupon
        /// </summary>
        [HttpPost("Delete")]
        public async Task<ActionResult> DeleteAsync(EntityDto<int> input)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(ProductController));

            await _productManager.DeleteAsync(input.Id);

            return Ok();
        }
    }

}
