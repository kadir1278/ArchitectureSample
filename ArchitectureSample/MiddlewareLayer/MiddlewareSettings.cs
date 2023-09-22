namespace MiddlewareLayer
{
    public class MiddlewareSettings
    {
        public bool HostFilterStatus { get; set; }
        public bool LoggerStatus { get; set; }
        public GlobalExceptionModel GlobalExceptionModel { get; set; }
    }

    public class GlobalExceptionModel
    {
        public bool Status { get; set; }
        public string UnauthorizedPath { get; set; }
    }
}
