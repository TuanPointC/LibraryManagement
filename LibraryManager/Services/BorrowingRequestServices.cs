using LibraryManager.DAO;
using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public class BorrowingRequestServices : IBorrowingRequestServices
    {
        private readonly IBorrowingRequestRepo _borrowingRequestRepo;
        public BorrowingRequestServices(IBorrowingRequestRepo borrowingRequestRepo)
        {
            _borrowingRequestRepo = borrowingRequestRepo;
        }
        public bool CreateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            try
            {
                if (borrowingRequest != null)
                {
                    _borrowingRequestRepo.CreateBorrowingRequest(borrowingRequest);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBorrowingRequest(Guid id)
        {
            try
            {
                _borrowingRequestRepo.DeleteBorrowingRequest(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public BorrowingRequestDto GetBorrowingRequestById(Guid id)
        {
            return _borrowingRequestRepo.GetBorrowingRequestById(id);
        }

        public IEnumerable<BorrowingRequestDto> GetBorrowingRequests()
        {
            return _borrowingRequestRepo.GetBorrowingRequests();
        }

        public bool UpdateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            try
            {
                if (borrowingRequest != null)
                {
                    _borrowingRequestRepo.UpdateBorrowingRequest(borrowingRequest);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
