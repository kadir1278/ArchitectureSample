﻿namespace CoreLayer.Utilities.Results.Abstract
{
    public interface IDataResult<out T>
    {
        public bool IsSuccess { get; set; }
        public string? Messages { get; set; }
        public T Data { get; }
    }
}
