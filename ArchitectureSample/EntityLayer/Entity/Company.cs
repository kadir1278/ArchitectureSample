using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    [Table("Company", Schema = "dbo")]
    public class Company : BaseEntity
    {
        public Company()
        {
            this.Users = new HashSet<User>();
            this.ValidationRules = new HashSet<ValidationRule>();
        }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<ValidationRule> ValidationRules { get; set; }
    }
}
