using EntityLayer.Base;

namespace EntityLayer.Entity
{
    public class ProjectOwner : BaseEntity
    {
        public string ProjectName { get; set; }
        public string Owner { get; set; }
        public string Domain { get; set; }
        public DateTime StartDate { get; set; }
    }
}
