using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public interface IBorrowingRequestServices
    {
        public IEnumerable<BorrowingRequestDto> GetBorrowingRequests();
        public BorrowingRequestDto GetBorrowingRequestById(Guid id);
        public bool CreateBorrowingRequest(BorrowingRequestDto borrowingRequest);
        public bool UpdateBorrowingRequest(BorrowingRequestDto borrowingRequest);
        public bool DeleteBorrowingRequest(Guid id);
    }
}
