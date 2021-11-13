using LibraryManager.DTOs;
using LibraryManager.Models;
using LibraryManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryService;
        public CategoryController(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var listCategories = _categoryService.GetCategories();
            if (listCategories.Any())
            {
                return Ok(listCategories);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult GetCategoryById(Guid id)
        {
            var b = _categoryService.GetCategoryById(id);
            if (b != null)
            {
                return Ok(b);
            }
            return NotFound();
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public ActionResult CreateCategory(CategoryDto category)
        {
            var signal = _categoryService.CreateCategory(category);
            if (signal=="Ok")
            {
                return Ok();
            }
            return BadRequest(signal);
        }

        [HttpPut]
        //[Authorize(Roles = "admin")]
        public ActionResult UpdateCategory(CategoryDto category)
        {
            var signal = _categoryService.UpdateCategory(category);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public ActionResult DeleteCategory(Guid id)
        {
            var signal = _categoryService.DeleteCategory(id);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
