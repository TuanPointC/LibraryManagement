using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class Category
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
