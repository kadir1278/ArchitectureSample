using BusinessLayer.Abstract;
using EntityLayer.Dto.User;
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

        [HttpGet("list-user")]
        public IActionResult ListUser()
        {
            try
            {
                var result = _userService.GetUserCollection();
                if (!result.IsSuccess) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("add-user")]
        public IActionResult AddUser(UserAddDto model)
        {
            try
            {
                var result = _userService.AddUser(model);
                if (!result.IsSuccess) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
