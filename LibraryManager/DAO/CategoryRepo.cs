using AutoMapper;
using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly LibraryManagerDbContext _libraryManagerDbContext;
        public CategoryRepo(LibraryManagerDbContext libraryManagerDbContext)
        {
            _libraryManagerDbContext = libraryManagerDbContext;
        }
        public void CreateCategory(Category category)
        {
            _libraryManagerDbContext.Categories.Add(category);
            _libraryManagerDbContext.SaveChanges();
        }

        public void DeleteCategory(Guid id)
        {
            var currentCategoriy = _libraryManagerDbContext.Categories.Where(b => b.Id == id).FirstOrDefault();
            _libraryManagerDbContext.Categories.Remove(currentCategoriy);
            _libraryManagerDbContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _libraryManagerDbContext.Categories.ToList();
        }

        public Category GetCategoryById(Guid id)
        {
            return _libraryManagerDbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public void UpdateCategory(Category category)
        {
            var currentCategory = _libraryManagerDbContext.Categories.Single(b => b.Id == category.Id);
            currentCategory.Name = category.Name;
            _libraryManagerDbContext.SaveChanges();
        }
    }
}
