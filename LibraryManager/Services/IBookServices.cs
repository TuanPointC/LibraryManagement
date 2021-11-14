using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public interface IBookServices
    {
        public IEnumerable<BookDto> GetBooks();
        public BookDto GetBookById(Guid id);
        public string CreateBook(BookDto book);
        public string UpdateBook(BookDto book);
        public string DeleteBook(Guid id);
    }
}
