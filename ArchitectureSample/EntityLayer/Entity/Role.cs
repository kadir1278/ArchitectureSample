using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
