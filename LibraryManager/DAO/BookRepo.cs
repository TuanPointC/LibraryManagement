using AutoMapper;
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
        private readonly IMapper _mapper;
        public BookRepo(LibraryManagerDbContext libraryManagerDbContext, IMapper mapper)
        {
            _libraryManagerDbContext = libraryManagerDbContext;
            _mapper = mapper;
        }

        public void CreateBook(BookDto book)
        {
            Book b = _mapper.Map<Book>(book);
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
            BookDto b = _mapper.Map<BookDto>(currentBook);
            return b;
        }

        public IEnumerable<BookDto> GetBooks()
        {

            return _mapper.Map<List<BookDto>>(_libraryManagerDbContext.Books.ToList());
        }

        public void UpdateBook(BookDto book)
        {
            var currentBook = _libraryManagerDbContext.Books.Where(b => b.Id == book.Id).FirstOrDefault();
            currentBook = _mapper.Map<Book>(book);
            _libraryManagerDbContext.SaveChanges();
        }
    }
}
