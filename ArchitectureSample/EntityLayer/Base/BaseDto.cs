using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Base
{
    public class BaseDto : IDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
