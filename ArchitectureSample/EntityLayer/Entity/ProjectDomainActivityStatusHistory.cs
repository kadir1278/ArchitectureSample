using CoreLayer.Entity.Base;

namespace EntityLayer.Entity
{
    public class ProjectDomainActivityStatusHistory : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid DomainId { get; set; }
        public Domain Domain { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
