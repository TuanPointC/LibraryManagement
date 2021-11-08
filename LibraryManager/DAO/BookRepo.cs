using LibraryManager.DTOs;
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

        public void CreateBook(BookDto book)
        {
            var b = new Book();
            b.Author = book.Author;
            b.Name = book.Name;
            b.CategoryId = book.CategoryId;
            b.Summary = book.Summary;
            b.UrlImage = book.UrlImage;

            _libraryManagerDbContext.Books.Add(b);
            _libraryManagerDbContext.SaveChanges();
        }

        public void DeleteBook(Guid id)
        {
            var currentBook = _libraryManagerDbContext.Books.Where(b => b.Id == id).FirstOrDefault();
            _libraryManagerDbContext.Books.Remove(currentBook);
            _libraryManagerDbContext.SaveChanges();
        }

        public BookDto GetBookById(Guid id)
        {
            var currentBook = _libraryManagerDbContext.Books.Where(b => b.Id == id).FirstOrDefault();
            var b = new BookDto();
            b.Author = currentBook.Author;
            b.Name = currentBook.Name;
            b.CategoryId = currentBook.CategoryId;
            b.Summary = currentBook.Summary;
            b.UrlImage = currentBook.UrlImage;
            return b;
        }

        public IEnumerable<BookDto> GetBooks()
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
