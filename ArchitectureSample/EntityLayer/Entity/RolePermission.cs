﻿using CoreLayer.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

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
