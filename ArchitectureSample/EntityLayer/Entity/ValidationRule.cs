using CoreLayer.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entity
{
    [Table("ValidationRule", Schema = "dbo")]
    public class ValidationRule : BaseEntity
    {
        public string ValidatorName { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
