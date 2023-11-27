namespace CoreLayer.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        public ErrorDataResult(Exception exception)
        {
            IsSuccess = false;
            Messages = exception.Message;
        }
        public ErrorDataResult(string errorMessage)
        {
            IsSuccess = false;
            Messages = errorMessage;

        }
    }
}
