using CoreLayer.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("Role", Schema = "dbo")]
    public class Role : BaseEntity
    {
        public Role()
        {
            this.RolePermissions = new HashSet<RolePermission>();
        }
        public Guid? ParentId { get; set; }
        public virtual Role Parent { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

    }
}
