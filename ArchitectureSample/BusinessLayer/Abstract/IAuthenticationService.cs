using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.ViewModel.Authentication;

namespace BusinessLayer.Abstract
{
    public interface IAuthenticationService
    {
        IDataResult<LoginResponseViewModel> Login(string username, string password);
        IDataResult<bool> Logout(string username, string password);
    }
}
