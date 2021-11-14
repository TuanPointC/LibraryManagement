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
        public string CreateBorrowingRequest(BorrowingRequestDto borrowingRequest);
        public string UpdateBorrowingRequest(BorrowingRequestDto borrowingRequest);
        public string DeleteBorrowingRequest(Guid id);
        public IEnumerable<RequestUser> GetBorrowingRequestByUserId(Guid id);
    }
}
