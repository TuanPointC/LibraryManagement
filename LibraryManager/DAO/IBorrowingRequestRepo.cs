using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public interface IBorrowingRequestRepo
    {
        public IEnumerable<BorrowingRequestDto> GetBorrowingRequests();
        public BorrowingRequestDto GetBorrowingRequestById(Guid id);
        public void CreateBorrowingRequest(BorrowingRequestDto borrowingRequest);
        public void UpdateBorrowingRequest(BorrowingRequestDto borrowingRequest);
        public void DeleteBorrowingRequest(Guid id);
    }
}
