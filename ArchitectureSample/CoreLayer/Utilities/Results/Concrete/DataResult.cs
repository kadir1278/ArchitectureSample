﻿using CoreLayer.Utilities.Results.Abstract;

namespace CoreLayer.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
