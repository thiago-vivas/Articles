using Application.Managers.Interfaces;
using Application.Models;
using AutoMapper;
using Data.DataAccess.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private ICategoryRepository CategoryRepository { get; }
        private IMapper Mapper { get; }
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.CategoryRepository = categoryRepository;
            this.Mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var response = this.CategoryRepository.GetCategories();

            return Mapper.Map<IEnumerable<CategoryDto>>(response);
        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            var response = this.CategoryRepository.GetCategoryById(categoryId);
            return Mapper.Map<CategoryDto>(response);
        }
        public CategoryDto CreateCategory(CategoryDto category)
        {
            var entity = Mapper.Map<Category>(category);
            var response = this.CategoryRepository.CreateCategory(entity);

            return Mapper.Map<CategoryDto>(response);
        }
    }
}
