using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public interface IBorrowingRequestRepo
    {
        public IEnumerable<BorrowingRequest> GetBorrowingRequests();
        public BorrowingRequest GetBorrowingRequestById(Guid id);
        public void CreateBorrowingRequest(BorrowingRequest borrowingRequest);
        public void UpdateBorrowingRequest(BorrowingRequest borrowingRequest);
        public void DeleteBorrowingRequest(Guid id);
    }
}
