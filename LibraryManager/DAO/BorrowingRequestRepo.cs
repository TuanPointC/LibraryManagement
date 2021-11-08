using AutoMapper;
using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public class BorrowingRequestRepo : IBorrowingRequestRepo
    {
        private readonly LibraryManagerDbContext _libraryManagerDbContext;
        private readonly IMapper _mapper;
        public BorrowingRequestRepo(LibraryManagerDbContext libraryManagerDbContext, IMapper mapper)
        {
            _libraryManagerDbContext = libraryManagerDbContext;
            _mapper = mapper;
        }
        public void CreateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            var br = _mapper.Map<BorrowingRequest>(borrowingRequest);
            _libraryManagerDbContext.BorrowingRequests.Add(br);
            _libraryManagerDbContext.SaveChanges();
        }

        public void DeleteBorrowingRequest(Guid id)
        {
            var currentBorrowingRequest = _libraryManagerDbContext.BorrowingRequests.Where(b => b.Id == id).FirstOrDefault();
            _libraryManagerDbContext.BorrowingRequests.Remove(currentBorrowingRequest);
            _libraryManagerDbContext.SaveChanges();
        }

        public BorrowingRequestDto GetBorrowingRequestById(Guid id)
        {
            return _mapper.Map<BorrowingRequestDto>(_libraryManagerDbContext.BorrowingRequests.Where(b => b.Id == id).FirstOrDefault());
        }

        public IEnumerable<BorrowingRequestDto> GetBorrowingRequests()
        {
            return _mapper.Map<List<BorrowingRequestDto>>(_libraryManagerDbContext.BorrowingRequests.ToList());
        }

        public void UpdateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            var currentBorrowingRequest = _libraryManagerDbContext.BorrowingRequests.Where(b => b.Id == borrowingRequest.Id).FirstOrDefault();
            currentBorrowingRequest = _mapper.Map<BorrowingRequest>(borrowingRequest);
            _libraryManagerDbContext.SaveChanges();
        }
    }
}
