using Core.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Core.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return Ok(await usersService.GetById(id));
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            await usersService.Register(register);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            await usersService.Login(login);
            return Ok();
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await usersService.Logout();
            return Ok();
        }
    }
}
