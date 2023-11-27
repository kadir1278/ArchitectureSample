namespace CoreLayer.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data)
        {
            IsSuccess = true;
            Data = data;
        }
        public SuccessDataResult(T data, string message)
        {
            IsSuccess = true;
            Data = data;
            Messages = message;
        }
    }
}
