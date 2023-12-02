using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helper
{
    public static class CookieHelper
    {
        public static string GetCookie(string key)
        {
            try
            {
                HttpContext _context = HttpContextHelper.GetHttpContext();
                string value;
                _context.Request.Cookies.TryGetValue(key, out value);
                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string SetCookie(string key, string value, CookieOptions? cookieOptions = null)
        {
            try
            {
                HttpContext _context = HttpContextHelper.GetHttpContext();
                if (cookieOptions is null)
                    _context.Response.Cookies.Append(key, value);
                else
                    _context.Response.Cookies.Append(key, value, cookieOptions);
                return value;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
