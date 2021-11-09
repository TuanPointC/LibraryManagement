﻿using AutoMapper;
using LibraryManager.DAO;
using LibraryManager.DTOs;
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
        private readonly IMapper _mapper;
        public CategoryServices(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public string CreateCategory(CategoryDto category)
        {
            try
            {
                if (category != null)
                {
                    _categoryRepo.CreateCategory(_mapper.Map<CategoryDto,Category>(category));
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

        public IEnumerable<CategoryDto> GetCategories()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_categoryRepo.GetCategories());
        }

        public CategoryDto GetCategoryById(Guid id)
        {
            return _mapper.Map<Category, CategoryDto>(_categoryRepo.GetCategoryById(id));
        }

        public bool UpdateCategory(CategoryDto category)
        {
            try
            {
                if (category != null)
                {
                    _categoryRepo.UpdateCategory(_mapper.Map<CategoryDto,Category>(category));
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
