namespace CoreLayer.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(Exception exception)
        {
            this.IsSuccess = false;
            this.Messages.Add(exception.Message);
        }
        public ErrorDataResult(string errorMessage)
        {
            this.IsSuccess = false;
            this.Messages.Add(errorMessage);
        }
    }
}
