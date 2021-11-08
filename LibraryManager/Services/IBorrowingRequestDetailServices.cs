using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public interface IBorrowingRequestDetailServices
    {
        public IEnumerable<BorrowingRequestDetailDto> GetBorrowingRequestDetails();
        public BorrowingRequestDetailDto GetBorrowingRequestDetailById(Guid id);
        public bool CreateBorrowingRequestDetail(BorrowingRequestDetailDto borrowingRequestDetail);
        public bool UpdateBorrowingRequestDetail(BorrowingRequestDetailDto borrowingRequestDetail);
        public bool DeleteBorrowingRequestDetail(Guid id);
    }
}
