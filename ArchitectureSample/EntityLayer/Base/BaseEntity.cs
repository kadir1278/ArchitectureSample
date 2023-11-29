using CoreLayer.DataAccess.Abstract;
using CoreLayer.DataAccess.Constants;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Base
{
    public class BaseEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CultureInfo { get; set; } = CultureInfoHelper.Turkish;
        public bool IsActive { get; set; }

    }
}
