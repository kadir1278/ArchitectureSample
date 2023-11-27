namespace CoreLayer.Entity.Dtos
{
    public class MiddlewareSettings
    {
        public bool HostFilterStatus { get; set; } = true;
        public bool LoggerStatus { get; set; } = true;
        public bool CheckProjectStatus { get; set; } = true;
    }
}
