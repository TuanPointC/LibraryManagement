using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string UrlImage { get; set; }
        public string Summary { get; set; }
        public Guid CategoryId { get; set; }
    }
}
