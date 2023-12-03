using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    [Table("RolePermission", Schema = "dbo")]

    public class RolePermission : BaseEntity
    {
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        public Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
