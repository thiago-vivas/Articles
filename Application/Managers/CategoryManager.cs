using Data.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Managers
{
    public class CategoryManager
    {
        public ICategoryRepository CategoryRepository { get; }
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
        }
    }
}
