using LibraryManager.DTOs;
using LibraryManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var listUsers = _userServices.GetUsers();
            if (listUsers.Any())
            {
                return Ok(listUsers);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult GetUserById(Guid id)
        {
            var b = _userServices.GetUserById(id);
            if (b != null)
            {
                return Ok(b);
            }
            return NotFound();
        }

        [HttpPost]
       [Authorize(Roles = "admin")]
        public ActionResult CreateUser(UserDto user)
        {
            var signal = _userServices.CreateUser(user);
            if (signal=="ok")
            {
                return Ok(user);
            }
            return BadRequest(signal);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public ActionResult UpdateUser(UserDto user)
        {
            var signal = _userServices.UpdateUser(user);
            if (signal=="ok")
            {
                return Ok();
            }
            return BadRequest(signal);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteUser(Guid id)
        {
            var signal = _userServices.DeleteUser(id);
            if (signal=="ok")
            {
                return Ok();
            }
            return BadRequest(signal);
        }

    }
}
