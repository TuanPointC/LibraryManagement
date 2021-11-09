using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class BorrowingRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid WhoRequestId { get; set; }
        public User User { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime HandledDate { get; set; }
        public string Status { get; set; }
        public Guid WhoHandleId { get; set; }
        public ICollection<BorrowingRequestDetail> BorrowingRequestDetails{ get; set; }

    }
}
