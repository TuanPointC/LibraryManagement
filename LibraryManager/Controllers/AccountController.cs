using AutoMapper;
using LibraryManager.DTOs;
using LibraryManager.Helper;
using LibraryManager.Models;
using LibraryManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IUserServices _userService;
        private IMapper _mapper;
        private ITokenService _JWTAuthentication;
        public AccountController(IUserServices userService, IMapper mapper, ITokenService JWTAuthentication)
        {
            _userService = userService;
            _mapper = mapper;
            _JWTAuthentication = JWTAuthentication;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            var currentUser = _userService.GetUserByNameAndPassword(user.Name, user.Password);
            if (currentUser!=null)
            {
                var token = _JWTAuthentication.GenerateToken(_mapper.Map<UserDto, User>(currentUser));
                return Ok(
                  new
                  {
                      token=token,
                      userName= currentUser.Name,
                      userId=currentUser.Id,
                      userEmail=currentUser.Email,
                  }  
                  );
            }
            return Unauthorized();
        }

        

        public class LoginModel
        {
            public string Name { get; set; }
            public string Password { get; set; }
        }

        

    }
}
