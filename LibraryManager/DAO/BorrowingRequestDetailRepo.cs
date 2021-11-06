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
        public BorrowingRequestDetailRepo(LibraryManagerDbContext libraryManagerDbContext)
        {
            _libraryManagerDbContext = libraryManagerDbContext;
        }
        public void CreateBorrowingRequestDetail(BorrowingRequestDetail borrowingRequestDetail)
        {
            _libraryManagerDbContext.BorrowingRequestDetails.Add(borrowingRequestDetail);
            _libraryManagerDbContext.SaveChanges();
        }
        public void DeleteBorrowingRequestDetail(Guid id)
        {
            var currentBorrowingRequestDetail = _libraryManagerDbContext.BorrowingRequestDetails.Where(b => b.Id == id).FirstOrDefault();
            _libraryManagerDbContext.BorrowingRequestDetails.Remove(currentBorrowingRequestDetail);
            _libraryManagerDbContext.SaveChanges();
        }
        public BorrowingRequestDetail GetBorrowingRequestDetailById(Guid id)
        {
            var currentBorrowingRequestDetail = _libraryManagerDbContext.BorrowingRequestDetails.Where(b => b.Id == id).FirstOrDefault();
            return currentBorrowingRequestDetail;
        }

        public IEnumerable<BorrowingRequestDetail> GetBorrowingRequestDetails()
        {
            return _libraryManagerDbContext.BorrowingRequestDetails.ToList();
        }

        public void UpdateBorrowingRequestDetail(BorrowingRequestDetail borrowingRequestDetail)
        {
            var currentBorrowingRequestDetail = _libraryManagerDbContext.BorrowingRequestDetails.Where(b => b.Id == borrowingRequestDetail.Id).FirstOrDefault();
            currentBorrowingRequestDetail = borrowingRequestDetail;
            _libraryManagerDbContext.SaveChanges();
        }

    }
}
