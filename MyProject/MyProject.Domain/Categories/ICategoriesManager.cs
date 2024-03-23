using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Domain.Coupons;

namespace MyProject.Domain.Categories
{
    public interface ICategoriesManager
    {
        Task<List<CategoryDomain>> GetAllAsync();
    }
}
