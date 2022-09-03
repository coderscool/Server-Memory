using Microsoft.AspNetCore.Mvc;
using Server.Application.Catalog.Dtos.User;
using Server.Application.Catalog.Profile;
using Server.Application.UsersService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _usersService.GetAll();
            return Ok(users);
        }
        [HttpGet("login")]
        public async Task<IActionResult> GetUser([FromQuery] LoginRequest request)
        {
            var users = await _usersService.GetLoginUser(request);
            return Ok(users);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> GetUserId([FromQuery] UserQuery request)
        {
            var users = await _usersService.GetUserID(request.userId);
            if (users == null)
                return BadRequest();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterRequest request)
        {
            var result = await _usersService.RegisterUser(request);
            if (result == 0)
                return BadRequest();

            var user = await _usersService.GetUserID(result);

            return CreatedAtAction(nameof(GetUserId), new { userId = result }, user);
        }
    }
}
