using AutoMapper;
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
        private readonly IMapper _mapper;
        public BorrowingRequestServices(IBorrowingRequestRepo borrowingRequestRepo, IMapper mapper)
        {
            _borrowingRequestRepo = borrowingRequestRepo;
            _mapper = mapper;
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
            return _mapper.Map<BorrowingRequest, BorrowingRequestDto > (_borrowingRequestRepo.GetBorrowingRequestById(id));
        }

        public IEnumerable<BorrowingRequestDto> GetBorrowingRequests()
        {
            return _mapper.Map<IEnumerable<BorrowingRequest>,IEnumerable<BorrowingRequestDto>>(_borrowingRequestRepo.GetBorrowingRequests());
        }

        public bool UpdateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            try
            {
                if (borrowingRequest != null)
                {
                    _borrowingRequestRepo.UpdateBorrowingRequest(_mapper.Map<BorrowingRequestDto,BorrowingRequest>(borrowingRequest));
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
