using LibraryManager.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public interface IUserServices
    {
        public IEnumerable<UserDto> GetUsers();
        public UserDto GetUserById(Guid id);
        public bool CreateUser(UserDto book);
        public bool UpdateUser(UserDto book);
        public bool DeleteUser(Guid id);
        public UserDto GetUserByNameAndPassword(string name, string password);
    }
}
