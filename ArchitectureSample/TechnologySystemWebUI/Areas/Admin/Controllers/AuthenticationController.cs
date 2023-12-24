using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.User.Request;
using EntityLayer.Dto.User.Response;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CoreLayer.Helper;

namespace TechnologySystemWebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Route("admin/")]
    public class AuthenticationController : Controller
    {
        private readonly BusinessLayer.Abstract.IAuthenticationService _authenticationService;
        public AuthenticationController(BusinessLayer.Abstract.IAuthenticationService authenticationService)
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
                var identity = new ClaimsIdentity(responseDto.Data.OperationClaimDtos.Select(x => new Claim(ClaimTypes.Role, x.Name)),
                                                  CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                //CookieHelper.SetCookie("Authorization", $"{responseDto.Data.Token}", new CookieOptions()
                //{
                //    Expires = responseDto.Data.Expiration,
                //});
                return Redirect("/admin");
            }
            return View();
        }
    }
}
