using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Helper
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
