using LibraryManager.DTOs;
using LibraryManager.Models;
using LibraryManager.Services;
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
        public ActionResult GetlistBorrowingRequestById(Guid id)
        {
            var b = _borrowingRequestServices.GetBorrowingRequestById(id);
            if (b != null)
            {
                return Ok(b);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            var signal = _borrowingRequestServices.CreateBorrowingRequest(borrowingRequest);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult UpdateBorrowingRequest(BorrowingRequestDto borrowingRequest)
        {
            var signal = _borrowingRequestServices.UpdateBorrowingRequest(borrowingRequest);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBorrowingRequest(Guid id)
        {
            var signal = _borrowingRequestServices.DeleteBorrowingRequest(id);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
