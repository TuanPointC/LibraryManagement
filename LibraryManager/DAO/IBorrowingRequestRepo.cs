using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;

namespace LibraryManager.DAO
{
    public interface IBorrowingRequestRepo
    {
        public IEnumerable<BorrowingRequest> GetBorrowingRequests();
        public BorrowingRequest GetBorrowingRequestById(Guid id);
        public void CreateBorrowingRequest(BorrowingRequestDto borrowingRequest);
        public void UpdateBorrowingRequest(BorrowingRequest borrowingRequest);
        public void DeleteBorrowingRequest(Guid id);

        public IEnumerable<RequestUser> GetBorrowingRequestByUserId(Guid id);
    }
}
