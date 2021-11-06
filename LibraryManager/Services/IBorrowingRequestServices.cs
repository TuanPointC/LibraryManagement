using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public interface IBorrowingRequestServices
    {
        public IEnumerable<BorrowingRequest> GetBorrowingRequests();
        public BorrowingRequest GetBorrowingRequestById(Guid id);
        public bool CreateBorrowingRequest(BorrowingRequest borrowingRequest);
        public bool UpdateBorrowingRequest(BorrowingRequest borrowingRequest);
        public bool DeleteBorrowingRequest(Guid id);
    }
}
