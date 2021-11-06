using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public interface ICategoryServices
    {
        public IEnumerable<Category> GetCategories();
        public Category GetCategoryById(Guid id);
        public string CreateCategory(Category category);
        public bool UpdateCategory(Category category);
        public bool DeleteCategory(Guid id);
    }
}
