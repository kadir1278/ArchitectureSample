using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    [Table("Permission", Schema = "dbo")]
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
    }
}
