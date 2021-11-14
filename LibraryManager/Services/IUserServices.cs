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
        public string CreateUser(UserDto book);
        public string UpdateUser(UserDto book);
        public string DeleteUser(Guid id);
        public UserDto GetUserByNameAndPassword(string name, string password);
    }
}
