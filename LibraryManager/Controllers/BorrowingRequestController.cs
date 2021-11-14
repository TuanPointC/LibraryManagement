using LibraryManager.DTOs;
using LibraryManager.Models;
using LibraryManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("api/borrowing_request")]
    public class BorrowingRequestController : ControllerBase
    {
        private readonly IBorrowingRequestServices _borrowingRequestServices;
        public BorrowingRequestController(IBorrowingRequestServices borrowingRequestServices)
        {
            _borrowingRequestServices = borrowingRequestServices;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<BorrowingRequestDto>> GetBorrowingRequest()
        {
            var listBorrowingRequest= _borrowingRequestServices.GetBorrowingRequests();
            if (listBorrowingRequest.Any())
            {
                return Ok(listBorrowingRequest);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        public ActionResult GetlistBorrowingRequestByUserId(Guid id)
        {
            var b = _borrowingRequestServices.GetBorrowingRequestByUserId(id);
            if (b != null)
            {
                return Ok(b);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            if(borrowingRequest.ListBooks.Count>5)
            {
                return BadRequest("Only borrow maximum 5 books");
            }
            var signal = _borrowingRequestServices.CreateBorrowingRequest(borrowingRequest);
            if (signal=="ok")
            {
                return Ok();
            }
            return BadRequest(signal);
        }


        [HttpPut]
        [Authorize(Roles = "admin")]
        public ActionResult UpdateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            var signal = _borrowingRequestServices.UpdateBorrowingRequest(borrowingRequest);
            if (signal=="ok")
            {
                return Ok();
            }
            return BadRequest(signal);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteBorrowingRequest(Guid id)
        {
            var signal = _borrowingRequestServices.DeleteBorrowingRequest(id);
            if (signal=="ok")
            {
                return Ok();
            }
            return BadRequest(signal);
        }
    }
}
