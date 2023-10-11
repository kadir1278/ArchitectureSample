using EntityLayer.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("User", Schema = "dbo")]
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid ProjectOwnerId { get; set; }
        public virtual ProjectOwner ProjectOwner { get; set; }
    }
}
