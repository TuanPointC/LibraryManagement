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
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid WhoRequestId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        public Guid WhoHandleId { get; set; }

    }
}
