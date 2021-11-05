using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class BorrowingRequestDetail
    {
        public Guid Id { get; set; }
        public ICollection<Book> BooksRequest { get; set; }
        public Guid BorrowingRequestId { get; set; }
    }
}
