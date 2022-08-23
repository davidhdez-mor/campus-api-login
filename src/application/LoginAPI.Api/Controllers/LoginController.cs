using System.Threading.Tasks;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IJwtService _jwt;
        private readonly IUserService _userService;

        public LoginController(IJwtService jwt, IUserService userService)
        {
            _jwt = jwt;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserWriteDto userWriteDto)
        {
            var token = await _jwt.Authenticate(userWriteDto);
            if (token is null)
                return Unauthorized();

            return Ok(token);
        }
    }
}