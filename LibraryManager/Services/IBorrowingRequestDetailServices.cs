using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public interface IBorrowingRequestDetailServices
    {
        public IEnumerable<BorrowingRequestDetail> GetBorrowingRequestDetails();
        public BorrowingRequestDetail GetBorrowingRequestDetailById(Guid id);
        public bool CreateBorrowingRequestDetail(BorrowingRequestDetail borrowingRequestDetail);
        public bool UpdateBorrowingRequestDetail(BorrowingRequestDetail borrowingRequestDetail);
        public bool DeleteBorrowingRequestDetail(Guid id);
    }
}
