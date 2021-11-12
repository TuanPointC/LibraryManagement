using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public interface IUserRepo
    {
        public IEnumerable<User> GetUsers();
        public User GetUserById(Guid id);
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(Guid id);
        public User GetUserByNameAndPassword(string name, string password);
    }
}
