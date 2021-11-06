using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public interface IBookServices
    {
        public IEnumerable<Book> GetBooks();
        public Book GetBookById(Guid id);
        public bool CreateBook(Book book);
        public bool UpdateBook(Book book);
        public bool DeleteBook(Guid id);
    }
}
