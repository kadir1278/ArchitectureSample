namespace CoreLayer.Results.Concrete
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data)
        {
            this.IsSuccess = true;
            this.Data = data;
        }
    }
}
