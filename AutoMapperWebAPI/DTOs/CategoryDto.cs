using AutoMapperWebAPI.Entities;

namespace AutoMapperWebAPI.DTOs
{
    public class CategoryDto
    {
        public CategoryDto()
        {
            Products = new HashSet<ProductDto>();
        }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<ProductDto> Products { get; set; }
    }
}
