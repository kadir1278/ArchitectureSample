namespace CoreLayer.DataAccess.Abstract
{
    public interface IDto
    {
        public Guid Id { get; set; }
        public string CultureInfo { get; set; }
        public bool IsActive { get; set; }
    }
}
