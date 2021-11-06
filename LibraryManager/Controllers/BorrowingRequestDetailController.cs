
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
    [Route("api/borrowing_request_detail")]
    public class BorrowingRequestDetailController : ControllerBase
    {
        private readonly IBorrowingRequestDetailServices _borrowingRequestDetailServices;
        public BorrowingRequestDetailController(IBorrowingRequestDetailServices borrowingRequestDetailServices)
        {
            _borrowingRequestDetailServices = borrowingRequestDetailServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BorrowingRequest>> GetBorrowingRequestDetail()
        {
            var listBorrowingRequestDetail = _borrowingRequestDetailServices.GetBorrowingRequestDetails();
            if (listBorrowingRequestDetail.Any())
            {
                return Ok(listBorrowingRequestDetail);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult GetlistBorrowingRequestDetailById(Guid id)
        {
            var b = _borrowingRequestDetailServices.GetBorrowingRequestDetailById(id);
            if (b != null)
            {
                return Ok(b);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateBorrowingRequestDetail(BorrowingRequestDetail borrowingRequestDetail)
        {
            var signal = _borrowingRequestDetailServices.CreateBorrowingRequestDetail(borrowingRequestDetail);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult UpdateBorrowingRequestDetail(BorrowingRequestDetail borrowingRequestDetail)
        {
            var signal = _borrowingRequestDetailServices.UpdateBorrowingRequestDetail(borrowingRequestDetail);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBorrowingRequestDetail(Guid id)
        {
            var signal = _borrowingRequestDetailServices.DeleteBorrowingRequestDetail(id);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
