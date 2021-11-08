using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DTOs
{
    public class BorrowingRequestDetailDto
    {
        public Guid Id { get; set; }
        public Guid BorrowingRequestId { get; set; }
        public Guid BookId { get; set; }

    }
}
