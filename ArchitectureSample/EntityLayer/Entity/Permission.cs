using CoreLayer.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("Permission", Schema = "dbo")]
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
    }
}
