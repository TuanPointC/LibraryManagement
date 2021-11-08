using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public interface IBorrowingRequestDetailRepo
    {
        public IEnumerable<BorrowingRequestDetailDto> GetBorrowingRequestDetails();
        public BorrowingRequestDetailDto GetBorrowingRequestDetailById(Guid id);
        public void CreateBorrowingRequestDetail(BorrowingRequestDetailDto borrowingRequestDetail);
        public void UpdateBorrowingRequestDetail(BorrowingRequestDetailDto borrowingRequestDetail);
        public void DeleteBorrowingRequestDetail(Guid id);
    }
}
