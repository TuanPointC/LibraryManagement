using AutoMapper;
using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public class BorrowingRequestDetailRepo : IBorrowingRequestDetailRepo
    {
        private readonly LibraryManagerDbContext _libraryManagerDbContext;
        private readonly IMapper _mapper;
        public BorrowingRequestDetailRepo(LibraryManagerDbContext libraryManagerDbContext,IMapper mapper)
        {
            _libraryManagerDbContext = libraryManagerDbContext;
            _mapper = mapper;
        }
        public void CreateBorrowingRequestDetail(BorrowingRequestDetailDto borrowingRequestDetail)
        {
            var brdt = _mapper.Map<BorrowingRequestDetail>(borrowingRequestDetail);
            _libraryManagerDbContext.BorrowingRequestDetails.Add(brdt);
            _libraryManagerDbContext.SaveChanges();
        }
        public void DeleteBorrowingRequestDetail(Guid id)
        {
            var currentBorrowingRequestDetail = _libraryManagerDbContext.BorrowingRequestDetails.Where(b => b.Id == id).FirstOrDefault();
            _libraryManagerDbContext.BorrowingRequestDetails.Remove(currentBorrowingRequestDetail);
            _libraryManagerDbContext.SaveChanges();
        }
        public BorrowingRequestDetailDto GetBorrowingRequestDetailById(Guid id)
        {
            var currentBorrowingRequestDetail = _libraryManagerDbContext.BorrowingRequestDetails.Where(b => b.Id == id).FirstOrDefault();
            return _mapper.Map<BorrowingRequestDetailDto>(currentBorrowingRequestDetail);
        }

        public IEnumerable<BorrowingRequestDetailDto> GetBorrowingRequestDetails()
        {
            return _mapper.Map<List<BorrowingRequestDetailDto>>(_libraryManagerDbContext.BorrowingRequestDetails.ToList());
        }

        public void UpdateBorrowingRequestDetail(BorrowingRequestDetailDto borrowingRequestDetail)
        {
            var currentBorrowingRequestDetail = _libraryManagerDbContext.BorrowingRequestDetails.Where(b => b.Id == borrowingRequestDetail.Id).FirstOrDefault();
            currentBorrowingRequestDetail = _mapper.Map<BorrowingRequestDetail>(borrowingRequestDetail);
            _libraryManagerDbContext.SaveChanges();
        }

    }
}
