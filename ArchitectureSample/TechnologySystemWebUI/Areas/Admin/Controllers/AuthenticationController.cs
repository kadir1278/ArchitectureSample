using BusinessLayer.Abstract;
using CoreLayer.Helper;
using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.User.Request;
using EntityLayer.Dto.User.Response;
using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Route("admin/")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [Route("login"), HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login"), HttpPost]
        public IActionResult Login(UserLoginRequestDto loginModel)
        {
            IDataResult<UserLoginResponseDto> responseDto = _authenticationService.Login(loginModel);
            if (responseDto.IsSuccess)
            {
                CookieHelper.SetCookie("Authorization", responseDto.Data.Token, new CookieOptions()
                {
                    Expires = responseDto.Data.Expiration,
                });

                return Redirect("/admin");
            }

            return View();
        }
    }
}
