using CoreLayer.DataAccess.Abstract;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Base
{
    public class BaseEntity : IEntity
    {
        [Key]
        //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; }

    }
}
