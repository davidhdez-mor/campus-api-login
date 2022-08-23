using System.Threading.Tasks;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Api.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserWriteDto userWriteDto)
        {
            var user = await _userService.CreateUser(userWriteDto);
            return Created(Request.Path, user);
        }
    }
}