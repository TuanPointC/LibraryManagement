using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string UrlImage { get; set; }
        public string Summary { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category {get;set;}

        public ICollection<BorrowingRequestDetail> BorrowingRequestDetails{ get; set; }

    }
}
