using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;

        public UsersController(IUser iUser)
        {
            _user = iUser;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _user.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _user.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserRegisterDTO userDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            var user = await _user.RegisterUser(userDto);

            return CreatedAtAction("GetUser", new { id = user.userId }, user);
        }
    }
}
