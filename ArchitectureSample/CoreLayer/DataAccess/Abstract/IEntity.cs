namespace CoreLayer.DataAccess.Abstract
{
    public interface IEntity
    {
        public Guid Id { get; set; } 
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string CultureInfo { get; set; }
        public bool IsActive { get; set; }
    }
}
