using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public class BookRepo : IBookRepo
    {
        private readonly LibraryManagerDbContext _libraryManagerDbContext;
        public BookRepo(LibraryManagerDbContext libraryManagerDbContext)
        {
            _libraryManagerDbContext = libraryManagerDbContext;
        }

        public void CreateBook(Book book)
        {

            _libraryManagerDbContext.Books.Add(book);
            _libraryManagerDbContext.SaveChanges();
        }

        public void DeleteBook(Guid id)
        {
            var currentBook = _libraryManagerDbContext.Books.Where(b => b.Id == id).FirstOrDefault();
            _libraryManagerDbContext.Books.Remove(currentBook);
            _libraryManagerDbContext.SaveChanges();
        }

        public Book GetBookById(Guid id)
        {
            var currentBook = _libraryManagerDbContext.Books.Where(b => b.Id == id).FirstOrDefault();
            return currentBook;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _libraryManagerDbContext.Books.ToList();
        }

        public void UpdateBook(Book book)
        {
            var currentBook = _libraryManagerDbContext.Books.Where(b => b.Id == book.Id).FirstOrDefault();
            currentBook = book;
            _libraryManagerDbContext.SaveChanges();
        }
    }
}
