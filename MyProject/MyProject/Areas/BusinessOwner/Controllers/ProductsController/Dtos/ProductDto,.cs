namespace MyProject.Areas.BusinessOwner.Controllers.ProductsController.Dtos
{
    public class ProductDto
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Code { get; set; }

        public string? Tag { get; set; }

        public string? Color { get; set; }

        public string? Image { get; set; }

        public required string Description { get; set; }

        public DateTime? EXP { get; set; }
    }
}
