using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class Book
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string UrlImage { get; set; }
        public string Summary { get; set; }
        public Category Category { get; set}
    }
}
