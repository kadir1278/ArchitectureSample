using BusinessLayer.Abstract;
using EntityLayer.Dto.User.Request;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("list")]
        public object ListUser() => _userService.GetUserCollection();

        [HttpPost("add")]
        public object AddUser(UserAddRequestDto model) => _userService.AddUser(model);
    }
}
