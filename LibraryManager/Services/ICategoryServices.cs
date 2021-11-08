using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public interface ICategoryServices
    {
        public IEnumerable<CategoryDto> GetCategories();
        public CategoryDto GetCategoryById(Guid id);
        public string CreateCategory(CategoryDto category);
        public bool UpdateCategory(CategoryDto category);
        public bool DeleteCategory(Guid id);
    }
}
