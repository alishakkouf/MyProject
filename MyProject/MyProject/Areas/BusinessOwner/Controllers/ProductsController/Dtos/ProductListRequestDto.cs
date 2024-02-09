using MyProject.Shared.RequestDtos;

namespace MyProject.Areas.BusinessOwner.Controllers.ProductsController.Dtos
{
    public class ProductListRequestDto : PagedAndSortedResultRequestDto
    {
        public string? Keyword { get; set; }
    }
}
