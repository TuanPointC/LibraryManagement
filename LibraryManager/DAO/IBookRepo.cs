using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public interface IBookRepo
    {
        public IEnumerable<Book> GetBooks();
        public Book GetBookById(Guid id);
        public void CreateBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(Guid id);
    }
}
