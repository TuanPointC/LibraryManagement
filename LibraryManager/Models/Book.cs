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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200, ErrorMessage = "The property Name doesn't have more than 200 elements")]
        [Required]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "The property Author doesn't have more than 200 elements")]
        [Required]
        public string Author { get; set; }

        [Required]
        public string UrlImage { get; set; }

        [Required]
        public string Summary { get; set; }


        public BorrowingRequestDetail BorrowingRequestDetail { get; set; }

        public Category Category {get;set;}

    }
}
