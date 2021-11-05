using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class BorrowingRequest
    {
        public Guid Id { get; set; }
        public Guid WhoRequestId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public Guid WhoHandle { get; set; }
    }
}
