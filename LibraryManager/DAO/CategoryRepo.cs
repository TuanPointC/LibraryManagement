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
        private readonly IMapper _mapper;
        public CategoryRepo(LibraryManagerDbContext libraryManagerDbContext, IMapper mapper)
        {
            _libraryManagerDbContext = libraryManagerDbContext;
            _mapper = mapper;
        }
        public void CreateCategory(CategoryDto category)
        {
            var c = _mapper.Map<Category>(category);
            _libraryManagerDbContext.Categories.Add(c);
            _libraryManagerDbContext.SaveChanges();
        }

        public void DeleteCategory(Guid id)
        {
            var currentCategoriy = _libraryManagerDbContext.Categories.Where(b => b.Id == id).FirstOrDefault();
            _libraryManagerDbContext.Categories.Remove(currentCategoriy);
            _libraryManagerDbContext.SaveChanges();
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return _mapper.Map<List<CategoryDto>>(_libraryManagerDbContext.Categories.ToList());
        }

        public CategoryDto GetCategoryById(Guid id)
        {
            return _mapper.Map<CategoryDto> (_libraryManagerDbContext.Categories.Where(c => c.Id == id).FirstOrDefault());
        }

        public void UpdateCategory(CategoryDto category)
        {
            var currentCategoriy = _libraryManagerDbContext.Categories.Where(b => b.Id == category.Id).FirstOrDefault();
            currentCategoriy = _mapper.Map<Category>(category);
            _libraryManagerDbContext.SaveChanges();
        }
    }
}
