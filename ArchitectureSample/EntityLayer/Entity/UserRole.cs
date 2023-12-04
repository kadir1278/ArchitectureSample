using EntityLayer.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("UserRole", Schema = "dbo")]

    public class UserRole : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
