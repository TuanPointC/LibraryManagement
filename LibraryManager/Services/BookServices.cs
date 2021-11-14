using AutoMapper;
using LibraryManager.DAO;
using LibraryManager.DTOs;
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
        private readonly IMapper _mapper;
        public BookServices(IBookRepo bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public string CreateBook(BookDto book)
        {
            try
            {
                if (book != null)
                {
                    _bookRepo.CreateBook(_mapper.Map<BookDto, Book>(book));
                    return "ok";
                }
                return "Book is not null";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteBook(Guid id)
        {
            try
            {
                _bookRepo.DeleteBook(id);
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public BookDto GetBookById(Guid id)
        {
            return _mapper.Map<Book,BookDto>(_bookRepo.GetBookById(id));
        }

        public IEnumerable<BookDto> GetBooks()
        {
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(_bookRepo.GetBooks());
        }

        public string UpdateBook(BookDto book)
        {
            try
            {
                if (book != null)
                {
                    _bookRepo.UpdateBook(_mapper.Map<BookDto,Book>(book));
                    return "ok";
                }
                return "Book is not null";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
