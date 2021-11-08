using LibraryManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DBContext
{
    public class ApplicationDbContext:  IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions) : base(BbCo) {  }
    }
}
