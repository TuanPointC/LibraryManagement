using LibraryManager.DAO;
using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public class BorrowingRequestDetailServices : IBorrowingRequestDetailServices
    {
        private readonly IBorrowingRequestDetailRepo _borrowingRequestDetailRepo;
        public BorrowingRequestDetailServices(IBorrowingRequestDetailRepo borrowingRequestDetailRepo)
        {
            _borrowingRequestDetailRepo = borrowingRequestDetailRepo;
        }

        public bool CreateBorrowingRequestDetail(BorrowingRequestDetailDto borrowingRequestDetail)
        {
            try
            {
                if (borrowingRequestDetail != null)
                {
                    _borrowingRequestDetailRepo.CreateBorrowingRequestDetail(borrowingRequestDetail);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBorrowingRequestDetail(Guid id)
        {
            try
            {
                _borrowingRequestDetailRepo.DeleteBorrowingRequestDetail(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public BorrowingRequestDetailDto GetBorrowingRequestDetailById(Guid id)
        {
            return _borrowingRequestDetailRepo.GetBorrowingRequestDetailById(id);
            ;
        }

        public IEnumerable<BorrowingRequestDetailDto> GetBorrowingRequestDetails()
        {
            return _borrowingRequestDetailRepo.GetBorrowingRequestDetails();
        }

        public bool UpdateBorrowingRequestDetail(BorrowingRequestDetailDto borrowingRequestDetail)
        {
            try
            {
                if (borrowingRequestDetail != null)
                {
                    _borrowingRequestDetailRepo.UpdateBorrowingRequestDetail(borrowingRequestDetail);
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
