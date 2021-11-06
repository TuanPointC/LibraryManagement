using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public interface ICategoryRepo
    {
        public IEnumerable<Category> GetCategories();
        public Category GetCategoryById(Guid id);
        public void CreateCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(Guid id);
    }
}
