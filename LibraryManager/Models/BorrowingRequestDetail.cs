using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class BorrowingRequestDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid BookId{ get; set; }
        public Book Book { get; set; }

        public Guid BorrowingRequestId { get; set; }
        public BorrowingRequest BorrowingRequest{ get; set; }
    }
}
