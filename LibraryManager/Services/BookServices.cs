using LibraryManager.DAO;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepo _bookRepo;
        public BookServices(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public bool CreateBook(Book book)
        {
            try
            {
                if (book != null)
                {
                    _bookRepo.CreateBook(book);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBook(Guid id)
        {
            try
            {
                _bookRepo.DeleteBook(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Book GetBookById(Guid id)
        {
            return _bookRepo.GetBookById(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookRepo.GetBooks();
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                if (book != null)
                {
                    _bookRepo.UpdateBook(book);
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
