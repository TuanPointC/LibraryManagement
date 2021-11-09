using AutoMapper;
using LibraryManager.DAO;
using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        public UserServices(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public bool CreateUser(UserDto user)
        {
            try
            {
                if (user != null)
                {
                    _userRepo.CreateUser(_mapper.Map<UserDto,User>(user));
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                _userRepo.DeleteUser(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UserDto GetUserById(Guid id)
        {
            return _mapper.Map<User, UserDto>(_userRepo.GetUserById(id));
        }

        public IEnumerable<UserDto> GetUsers()
        {
            Console.WriteLine("service");
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(_userRepo.GetUsers());
        }

        public bool UpdateUser(UserDto user)
        {
            try
            {
                if (user != null)
                {
                    _userRepo.UpdateUser(_mapper.Map<UserDto, User>(user));
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
