using EntityLayer.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("Domain", Schema = "dbo")]
    public class Domain : BaseEntity
    {
        public Domain()
        {
            this.DomainActivityStatusHistories = new HashSet<ProjectDomainActivityStatusHistory>();
        }
        public string Name { get; set; }

        public virtual ICollection<ProjectDomainActivityStatusHistory> DomainActivityStatusHistories { get; set; }

    }
}
