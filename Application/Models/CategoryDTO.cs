using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CategoryDto
    {
        public CategoryDto()
        {
        }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
