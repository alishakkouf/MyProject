using MyProject.Shared.RequestDtos;

namespace MyProject.Areas.BusinessOwner.ProductsDtos
{
    public class ProductListRequestDto : PagedAndSortedResultRequestDto
    {
        public string? Keyword { get; set; }
    }
}
