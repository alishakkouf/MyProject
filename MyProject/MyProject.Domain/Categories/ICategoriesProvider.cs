using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Categories
{
    public interface ICategoriesProvider
    {
        public Task<List<CategoryDomain>> GetAllAsync();
    }
}
