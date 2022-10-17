using AutoMapper;
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
        private IMapper Mapper { get; }

        public ConversionController(IMapper mapper)
        {
            this.Mapper = mapper;
        }
        [HttpPost("FromCategoryDtoToCategoryEntity")]
        public Category PostFromCategoryDtoToCategoryEntity([FromBody] CategoryDto categoryDto)
        {
            return Mapper.Map<Category>(categoryDto);
        }
        [HttpPost( "FromCategoryEntityToCategoryDto")]
        public CategoryDto PostFromCategoryEntityToCategoryDto([FromBody] Category categoryEntity)
        {
            return Mapper.Map<CategoryDto>(categoryEntity);
        }
        [HttpPost( "FromProductDtoToProductEntity")]
        public Product PostFromProductDtoToProductEntity([FromBody] ProductDto productDto)
        {
            return Mapper.Map<Product>(productDto);
        }
        [HttpPost("FromProductEntityToProductDto")]
        public ProductDto PostFromProductEntityToProductDto([FromBody] Product productEntity)
        {
            return Mapper.Map<ProductDto>(productEntity);
        }
    }
}
