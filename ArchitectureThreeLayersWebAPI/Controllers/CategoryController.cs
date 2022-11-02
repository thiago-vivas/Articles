using Application.Managers;
using Application.Managers.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryManager CategoryManager { get; }
        public CategoryController(ICategoryManager categorymanager)
        {
            this.CategoryManager = categorymanager;
        }
        [HttpGet]
        public IEnumerable<CategoryDto> GetCategories()
        {
            return CategoryManager.GetCategories();
        }
        [HttpGet("{categoryId:int}")]
        public CategoryDto GetCategoryById(int categoryId)
        {
            return CategoryManager.GetCategoryById(categoryId);
        }
        [HttpPost]
        public CategoryDto PostCategory([FromBody] CategoryDto category)
        {
            return CategoryManager.CreateCategory(category);
        }
    }
}
