using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Localization;
using MyProject.Data.Models;
using MyProject.Domain.Categories;
using MyProject.Domain.Products;
using MyProject.Shared;
using MyProject.Shared.ResultDtos;

namespace MyProject.Data.Providers.Categories
{
    internal class CategoryProvider : GenericProvider<Category>, ICategoriesProvider
    {
        private readonly IStringLocalizer _localizer;
        private readonly IMapper _mapper;
        public CategoryProvider(IStringLocalizerFactory factory, MyProjectDbContext dbContext,
            IMapper mapper)
        {
            _localizer = factory.Create(typeof(CommonResource));
            DbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CategoryDomain>> GetAllAsync()
        {
            var data = await ActiveDbSet.ToListAsync();

            return _mapper.Map<List<CategoryDomain>>(data);
        }
    }
}
