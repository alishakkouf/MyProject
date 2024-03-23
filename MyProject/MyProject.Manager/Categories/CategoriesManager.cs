using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MyProject.Domain.Categories;
using MyProject.Domain.Coupons;
using MyProject.Shared;

namespace MyProject.Manager.Categories
{
    internal class CategoriesManager(ICategoriesProvider categoryProvider,
        IStringLocalizerFactory factory) : ICategoriesManager
    {

        private readonly ICategoriesProvider _categoryProvider = categoryProvider;
        private readonly IStringLocalizer _localizer = factory.Create(typeof(CommonResource));

        public async Task<List<CategoryDomain>> GetAllAsync()
        {
               return await _categoryProvider.GetAllAsync();
        }

    }
}
