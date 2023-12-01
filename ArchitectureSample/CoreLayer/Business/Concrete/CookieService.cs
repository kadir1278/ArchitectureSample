using CoreLayer.Business.Abstract;
using CoreLayer.Helper;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;

namespace CoreLayer.Business.Concrete
{
    public class CookieService : ICookieService
    {

        public IDataResult<string> GetCookie(string key)
        {
            try
            {
                HttpContext _context = HttpContextHelper.GetHttpContext();
                string value;
                _context.Request.Cookies.TryGetValue(key, out value);
                return new SuccessDataResult<string>(value);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(ex);
            }
        }

        public IDataResult<string> SetCookie(string key, string value, CookieOptions? cookieOptions)
        {
            try
            {
                HttpContext _context = HttpContextHelper.GetHttpContext();
                if (cookieOptions is null)
                    _context.Response.Cookies.Append(key, value);
                else
                    _context.Response.Cookies.Append(key, value, cookieOptions);
                return new SuccessDataResult<string>(value);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(ex);
            }

        }
    }
}
