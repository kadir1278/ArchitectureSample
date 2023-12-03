using EntityLayer.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("User", Schema = "dbo")]
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
