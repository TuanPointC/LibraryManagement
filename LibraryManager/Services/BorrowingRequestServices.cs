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
        public string CreateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            try
            {
                if (borrowingRequest != null)
                {
                    _borrowingRequestRepo.CreateBorrowingRequest(borrowingRequest);
                    return "ok";
                }
                return "borrowing request is not null";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteBorrowingRequest(Guid id)
        {
            try
            {
                _borrowingRequestRepo.DeleteBorrowingRequest(id);
                return "ok";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public BorrowingRequestDto GetBorrowingRequestById(Guid id)
        {
            return _mapper.Map<BorrowingRequest, BorrowingRequestDto > (_borrowingRequestRepo.GetBorrowingRequestById(id));
        }

        public IEnumerable<RequestUser> GetBorrowingRequestByUserId(Guid id)
        {
            return _borrowingRequestRepo.GetBorrowingRequestByUserId(id);
        }

        public IEnumerable<BorrowingRequestDto> GetBorrowingRequests()
        {
            return _mapper.Map<IEnumerable<BorrowingRequest>,IEnumerable<BorrowingRequestDto>>(_borrowingRequestRepo.GetBorrowingRequests());
        }

        public string UpdateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            try
            {
                if (borrowingRequest != null)
                {
                    _borrowingRequestRepo.UpdateBorrowingRequest(_mapper.Map<BorrowingRequestDto,BorrowingRequest>(borrowingRequest));
                    return "ok";
                }
                return "borrowing request is not null";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
