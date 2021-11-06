using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public interface IBorrowingRequestDetailRepo
    {
        public IEnumerable<BorrowingRequestDetail> GetBorrowingRequestDetails();
        public BorrowingRequestDetail GetBorrowingRequestDetailById(Guid id);
        public void CreateBorrowingRequestDetail(BorrowingRequestDetail borrowingRequestDetail);
        public void UpdateBorrowingRequestDetail(BorrowingRequestDetail borrowingRequestDetail);
        public void DeleteBorrowingRequestDetail(Guid id);
    }
}
