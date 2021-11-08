using LibraryManager.DTOs;
using System;
using System.Collections.Generic;

namespace LibraryManager.DAO
{
    public interface IBookRepo
    {
        public IEnumerable<BookDto> GetBooks();
        public BookDto GetBookById(Guid id);
        public void CreateBook(BookDto book);
        public void UpdateBook(BookDto book);
        public void DeleteBook(Guid id);
    }
}
