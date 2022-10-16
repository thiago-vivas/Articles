using AutoMapperWebAPI.DTOs;
using AutoMapperWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        [HttpPost(Name = "FromCategoryDtoToCategoryEntity")]
        public Category PostFromCategoryDtoToCategoryEntity([FromBody] CategoryDto category)
        {
            return new Category();
        }
        [HttpPost(Name = "FromCategoryEntityToCategoryDto")]
        public CategoryDto PostFromCategoryEntityToCategoryDto([FromBody] Category category)
        {
            return new CategoryDto();
        }
        [HttpPost(Name = "FromProductDtoToProductEntity")]
        public Product PostFromProductDtoToProductEntity([FromBody] ProductDto category)
        {
            return new Product();
        }
        [HttpPost(Name = "FromProductEntityToProductDto")]
        public ProductDto PostFromProductEntityToProductDto([FromBody] Product category)
        {
            return new ProductDto();
        }
    }
}
