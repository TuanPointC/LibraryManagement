using LibraryManager.DTOs;
using LibraryManager.Services;
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
        public ActionResult CreateUser(UserDto user)
        {
            var signal = _userServices.CreateUser(user);
            if (signal)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult UpdateUser(UserDto user)
        {
            var signal = _userServices.UpdateUser(user);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(Guid id)
        {
            var signal = _userServices.DeleteUser(id);
            if (signal)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
