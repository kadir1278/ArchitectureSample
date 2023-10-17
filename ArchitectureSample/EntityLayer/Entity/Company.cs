using EntityLayer.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("Company", Schema = "dbo")]
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Web { get; set; }
        public Guid ProjectOwnerId { get; set; }
        public virtual ProjectOwner ProjectOwner { get; set; }
    }
}
