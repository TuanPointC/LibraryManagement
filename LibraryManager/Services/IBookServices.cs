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
        public bool CreateBook(BookDto book);
        public bool UpdateBook(BookDto book);
        public bool DeleteBook(Guid id);
    }
}
