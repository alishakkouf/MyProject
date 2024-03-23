using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Products
{
    public class UpdateProductCommand
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Code { get; set; }

        public string? Tag { get; set; }

        public string? Color { get; set; }

        public string? Image { get; set; }

        public required string Description { get; set; }

        public DateTime? EXP { get; set; }

        public decimal? Price { get; set; }
    }
}
