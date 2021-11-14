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
        public string CreateUser(UserDto user)
        {
            try
            {
                if (user != null)
                {
                    _userRepo.CreateUser(_mapper.Map<UserDto,User>(user));
                    return "ok";
                }
                return "User is not null";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteUser(Guid id)
        {
            try
            {
                _userRepo.DeleteUser(id);
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public UserDto GetUserById(Guid id)
        {
            return _mapper.Map<User, UserDto>(_userRepo.GetUserById(id));
        }

        public UserDto GetUserByNameAndPassword(string name, string password)
        {
            return _mapper.Map<User, UserDto>(_userRepo.GetUserByNameAndPassword(name,password));
        }

        public IEnumerable<UserDto> GetUsers()
        {
            Console.WriteLine("service");
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(_userRepo.GetUsers());
        }

        public string UpdateUser(UserDto user)
        {
            try
            {
                if (user != null)
                {
                    _userRepo.UpdateUser(_mapper.Map<UserDto, User>(user));
                    return "ok";
                }
                return "User is not null";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
