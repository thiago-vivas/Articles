using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Managers.Interfaces
{
    public interface ICategoryManager
    {
        CategoryDto CreateCategory(CategoryDto category);
        IEnumerable<CategoryDto> GetCategories();
        CategoryDto GetCategoryById(int categoryId);
    }
}
