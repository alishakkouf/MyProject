using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Areas.Common.Dtos;
using MyProject.Domain.Categories;
using MyProject.Domain.Products;
using MyProject.Shared.ResultDtos;

namespace MyProject.Areas.Common.Categories
{
    public class CategoriesController(IStringLocalizerFactory factory,
           ICategoriesManager categoriesManager,
           ILogger<CategoriesController> logger,
           IMapper Mapper) : BaseCommonController(factory)
    {
        private readonly ILogger<CategoriesController> _logger = logger ?? throw new ArgumentNullException(nameof(factory));
        private readonly IMapper _mapper;
        private readonly ICategoriesManager _categoriesManager = categoriesManager;

        /// <summary>
        /// Get all Categories
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CategoryDto>>> GetAllAsync()
        {
            _logger.LogInformation($"Getting list of Categories via {nameof(GetAllAsync)} API");

            var data = await _categoriesManager.GetAllAsync();

            return Ok(_mapper.Map<List<CategoryDto>>(data));
        }
    }
}
