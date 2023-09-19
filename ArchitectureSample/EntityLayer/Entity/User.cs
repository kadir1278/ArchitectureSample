using EntityLayer.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("User", Schema = "dbo")]
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = false;
        public string Name { get; set; }
        public string Surname { get; set; }

        public User(string username, string password, string name, string surname, bool isactive = false)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.IsActive = isactive;

        }
    }
}
