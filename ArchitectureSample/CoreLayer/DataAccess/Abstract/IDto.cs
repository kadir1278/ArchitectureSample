namespace CoreLayer.DataAccess.Abstract
{
    public interface IDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
