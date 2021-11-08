using LibraryManager.DTOs;
using LibraryManager.Models;
using LibraryManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController: ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            var listBooks = _bookServices.GetBooks();
            if (listBooks.Any())
            {
                return Ok(listBooks);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult GetBookById(Guid id)
        {
            var b = _bookServices.GetBookById(id);
            if (b!=null)
            {
                return Ok(b);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateBook(BookDto book)
        {
            var signal = _bookServices.CreateBook(book);
            if (signal)
            {
                //Console.WriteLine(book.Category.Name);
                return Ok(book);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult UpdateBook(BookDto book)
        {
            var signal = _bookServices.UpdateBook(book);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id)
        {
            var signal = _bookServices.DeleteBook(id);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
