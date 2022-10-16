using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();

        Category GetCategoryById(int categoryId);

        Category CreateCategory(Category category);
    }
}
