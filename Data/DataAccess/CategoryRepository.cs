using Data.DataAccess.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private NorthwindContext DbContext { get; }
        public CategoryRepository(NorthwindContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.DbContext.Categories;
        }
        public Category GetCategoryById(int categoryId)
        {
            return DbContext.Categories.FirstOrDefault(x => x.CategoryId.Equals(categoryId));
        }
        public Category CreateCategory(Category category)
        {
            this.DbContext.Categories.Add(category);
            this.DbContext.SaveChanges();

            return category;
        }
    }
}
