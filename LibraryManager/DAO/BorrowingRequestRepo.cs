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
            using (var transaction = _libraryManagerDbContext.Database.BeginTransaction())
            {
                try
                {
                    // set condition; maximum 3 requests per month
                    var numberOfRequest = _libraryManagerDbContext.BorrowingRequests.Where(r => r.WhoRequestId == borrowingRequest.WhoRequestId && r.RequestedDate.Month == DateTime.Now.Month).Count();
                    if (numberOfRequest > 3)
                    {
                       throw new Exception("Cannot Over 3 requests per month");
                    }

                    // set condition maximum 5 books per user
                    //var allRequest = _libraryManagerDbContext.BorrowingRequests.Where(r => r.WhoRequestId == borrowingRequest.WhoRequestId && r.RequestedDate.Month == DateTime.Now.Month);
                    //var totalBook = 0;
                    //foreach (var request in allRequest)
                    //{
                    //    totalBook += _libraryManagerDbContext.BorrowingRequestDetails.Where(dt => dt.BorrowingRequestId == request.Id).Count();
                    //}
                    //if(totalBook + borrowingRequest.ListBooks.Count > 5)
                    //{
                    //    throw new Exception("Cannot over 5 books per user");
                    //}

                    // Add request
                    var listBorrowingDetail = new List<BorrowingRequestDetail>();
                    _libraryManagerDbContext.BorrowingRequests.Add(_mapper.Map<BorrowingRequestDto, BorrowingRequest>(borrowingRequest));

                    foreach (var book in borrowingRequest.ListBooks)
                    { 
                        var requestDetail = new BorrowingRequestDetail
                        {
                            Id = Guid.NewGuid(),
                            BookId = book.Id,
                            BorrowingRequestId = borrowingRequest.Id
                        };
                        listBorrowingDetail.Add(requestDetail);
                    }
                    _libraryManagerDbContext.BorrowingRequestDetails.AddRange(listBorrowingDetail);
                    _libraryManagerDbContext.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw new Exception("failed");
                }
            }


        }


        public void DeleteBorrowingRequest(Guid id)
        {
            var currentBorrowingRequest = _libraryManagerDbContext.BorrowingRequests.Where(b => b.Id == id).FirstOrDefault();
            _libraryManagerDbContext.BorrowingRequests.Remove(currentBorrowingRequest);
            _libraryManagerDbContext.SaveChanges();
        }

        public BorrowingRequest GetBorrowingRequestById(Guid id)
        {
            return _libraryManagerDbContext.BorrowingRequests.Where(b => b.Id == id).FirstOrDefault();
        }

        public IEnumerable<BorrowingRequest> GetBorrowingRequests()
        {
            return _libraryManagerDbContext.BorrowingRequests.ToList();
        }

        public void UpdateBorrowingRequest(BorrowingRequest borrowingRequest)
        {
            var currentBorrowingRequest = _libraryManagerDbContext.BorrowingRequests.Where(b => b.Id == borrowingRequest.Id).FirstOrDefault();
            currentBorrowingRequest.WhoUpdateId = borrowingRequest.WhoUpdateId;
            currentBorrowingRequest.WhoRequestId = borrowingRequest.WhoRequestId;
            currentBorrowingRequest.HandledDate = borrowingRequest.HandledDate;
            currentBorrowingRequest.RequestedDate = borrowingRequest.RequestedDate;
            currentBorrowingRequest.Status = borrowingRequest.Status;
            _libraryManagerDbContext.SaveChanges();
        }
    }
}
