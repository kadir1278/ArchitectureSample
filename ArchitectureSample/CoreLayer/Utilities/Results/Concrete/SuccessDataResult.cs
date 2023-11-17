using CoreLayer.Extensions;
using Microsoft.AspNetCore.Http;

namespace CoreLayer.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data)
        {
            IsSuccess = true;
            Data = data;
        }
    }
}
