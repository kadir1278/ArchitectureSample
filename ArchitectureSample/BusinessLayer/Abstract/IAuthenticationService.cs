using CoreLayer.Utilities.Results.Abstract;

namespace BusinessLayer.Abstract
{
    public interface IAuthenticationService
    {
       IDataResult<bool> Login(string username, string password );
        IDataResult<bool> Logout(string username, string password );
    }
}
