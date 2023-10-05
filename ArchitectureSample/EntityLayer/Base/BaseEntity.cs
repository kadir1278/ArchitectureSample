using CoreLayer.DataAccess.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; }

    }
}
