using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Shared.RequestDtos;

namespace MyProject.Domain.Business
{
    public class GetAllBusinessQuery : PagedAndSortedResultRequestDto
    {
        public string? Keyword { get; set; }

        public bool IsActive { get; set; }
    }
}
