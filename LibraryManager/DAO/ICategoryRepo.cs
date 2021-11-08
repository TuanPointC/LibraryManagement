using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public interface ICategoryRepo
    {
        public IEnumerable<CategoryDto> GetCategories();
        public CategoryDto GetCategoryById(Guid id);
        public void CreateCategory(CategoryDto category);
        public void UpdateCategory(CategoryDto category);
        public void DeleteCategory(Guid id);
    }
}
