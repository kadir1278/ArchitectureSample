using CoreLayer.Extensions;
using CoreLayer.Helper;
using Microsoft.AspNetCore.Http;

namespace CoreLayer.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        public ErrorDataResult(Exception exception)
        {
            IsSuccess = false;
            Messages.Add(exception.Message);
        }
        public ErrorDataResult(string errorMessage)
        {
            IsSuccess = false;
            Messages.Add(errorMessage);

        }
    }
}
