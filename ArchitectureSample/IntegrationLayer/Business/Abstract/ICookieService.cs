using CoreLayer.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;

namespace IntegrationLayer.Business.Abstract
{
    public interface ICookieService
    {
        IDataResult<string> GetCookie(string key);
        IDataResult<string> SetCookie(string key, string value, CookieOptions? cookieOptions = default);
    }
}
