namespace MyProject.Areas.BusinessOwner.ProductsDtos
{
    public class CreateProductRequestDto
    {
        public required string Name { get; set; }

        public required string Code { get; set; }

        public string? Tag { get; set; }

        public string? Color { get; set; }

        public string? Image { get; set; }

        public required string Description { get; set; }

        public DateTime? EXP { get; set; }

        public decimal Price { get; set; }
    }
}
