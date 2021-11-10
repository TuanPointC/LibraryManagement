using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    public class UserRepo : IUserRepo
    {
        private readonly LibraryManagerDbContext _libraryManagerDbContext;
        public UserRepo(LibraryManagerDbContext libraryManagerDbContext)
        {
            _libraryManagerDbContext = libraryManagerDbContext;
        }
        public void CreateUser(User user)
        {
            _libraryManagerDbContext.Users.Add(user);
            _libraryManagerDbContext.SaveChanges();
        }

        public void DeleteUser(Guid id)
        {
            var currentUser = _libraryManagerDbContext.Users.Where(b => b.Id == id).FirstOrDefault();
            _libraryManagerDbContext.Users.Remove(currentUser);
            _libraryManagerDbContext.SaveChanges();
        }

        public User GetUserById(Guid id)
        {
            var currentUser = _libraryManagerDbContext.Users.Where(b => b.Id == id).FirstOrDefault();
            return currentUser;
        }

        public IEnumerable<User> GetUsers()
        {
            return _libraryManagerDbContext.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            var currentUser = _libraryManagerDbContext.Users.Single(b => b.Id == user.Id);
            currentUser.Name = user.Name;
            currentUser.Email = user.Email;
            currentUser.Password = user.Password;
            currentUser.Role = user.Role;
            _libraryManagerDbContext.SaveChanges();
        }
    }
}
