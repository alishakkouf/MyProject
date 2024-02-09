using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Shared.RequestDtos;

namespace MyProject.Domain.Products
{
    public class ProductListQuery : PagedAndSortedResultRequestDto
    {
        public string? Keyword { get; set; }
    }
}
