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
        public BorrowingRequestRepo(LibraryManagerDbContext libraryManagerDbContext)
        {
            _libraryManagerDbContext = libraryManagerDbContext;
        }
        public void CreateBorrowingRequest(BorrowingRequest borrowingRequest)
        {
            _libraryManagerDbContext.BorrowingRequests.Add(borrowingRequest);
            _libraryManagerDbContext.SaveChanges();
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
            currentBorrowingRequest = borrowingRequest;
            _libraryManagerDbContext.SaveChanges();
        }
    }
}
