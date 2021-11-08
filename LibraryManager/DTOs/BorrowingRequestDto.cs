using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DTOs
{
    public class BorrowingRequestDto
    {
        public Guid Id { get; set; }
        public Guid WhoRequestId { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime HandledDate { get; set; }
        public string Status { get; set; }
        public Guid WhoHandleId { get; set; }
    }
}
