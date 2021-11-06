using LibraryManager.DAO;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryServices(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public string CreateCategory(Category category)
        {
            try
            {
                if (category != null)
                {
                    _categoryRepo.CreateCategory(category);
                    return "Ok";
                }
                return "Category must not null";
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }

        public bool DeleteCategory(Guid id)
        {
            try
            {
                _categoryRepo.DeleteCategory(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepo.GetCategories();
        }

        public Category GetCategoryById(Guid id)
        {
            return _categoryRepo.GetCategoryById(id);
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                if (category != null)
                {
                    _categoryRepo.UpdateCategory(category);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
