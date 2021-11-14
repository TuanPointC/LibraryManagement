using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DTOs
{
    public class RequestUser
    {
        public DateTime RequestedDate { get; set; }
        public string BookName { get; set; }
        public string Status { get; set; }
    }
}
