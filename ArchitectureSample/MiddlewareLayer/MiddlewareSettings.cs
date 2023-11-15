namespace MiddlewareLayer
{
    public class MiddlewareSettings
    {
        public bool HostFilterStatus { get; set; } = true;
        public bool LoggerStatus { get; set; } = true;
        public bool CheckProjectStatus { get; set; } = true;
        public GlobalExceptionModel GlobalExceptionModel { get; set; }
    }

    public class GlobalExceptionModel
    {
        public bool Status { get; set; }
        public string UnauthorizedPath { get; set; }
    }
}
