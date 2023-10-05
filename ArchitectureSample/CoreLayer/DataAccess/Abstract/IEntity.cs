using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DataAccess.Abstract
{
    public interface IEntity
    {
       
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
