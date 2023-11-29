using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    [Table("ValidationRule", Schema = "dbo")]
    public class ValidationRule : BaseEntity
    {
        public string ValidatorName { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }
    }
}
