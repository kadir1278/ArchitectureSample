using CoreLayer.Utilities.Results.Abstract;

namespace CoreLayer.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Messages { get; set; }
    }
}
