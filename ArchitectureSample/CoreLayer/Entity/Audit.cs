using CoreLayer.Entity.Base;

namespace CoreLayer.Entity
{
    public class Audit : BaseEntity
    {
        public string LogMessage { get; set; }
        public string Request { get; set; }
        public string TargetTable { get; set; }
        public string ContextRequestId { get; set; }
    }
}
