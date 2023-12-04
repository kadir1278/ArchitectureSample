using EntityLayer.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("Project", Schema = "dbo")]

    public class Project : BaseEntity
    {
        public Project()
        {
            this.ProjectDomainActivityStatusHistories = new HashSet<ProjectDomainActivityStatusHistory>();
        }
        public string Name { get; set; }

        public virtual ICollection<ProjectDomainActivityStatusHistory> ProjectDomainActivityStatusHistories { get; set; }
    }
}
