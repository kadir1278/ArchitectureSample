using BusinessLayer.Abstract;
using EntityLayer.Dto.User;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _logger = logger;
            _logger.LogInformation($"Request UserController constructor has ready {httpContextAccessor.HttpContext.Items["RequestId"].ToString()}");
        }

        [HttpGet("list-user")]
        //[ClientIpCheckActionFilter]
        public IActionResult ListUser()
        {
            try
            {
                var result = _userService.GetUserCollection();
                if (!result.IsSuccess) return BadRequest(result);

                return Ok(result);
            }
            catch (SecurityException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
