using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DBContext
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
    }
}
