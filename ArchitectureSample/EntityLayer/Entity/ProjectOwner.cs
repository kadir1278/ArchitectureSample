using EntityLayer.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("ProjectOwner", Schema = "dbo")]
    public class ProjectOwner : BaseEntity
    {
        public ProjectOwner()
        {
            this.Users = new HashSet<User>();
        }
        public string ProjectName { get; set; }
        public string Owner { get; set; }
        public string Domain { get; set; }
        public DateTime StartDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
