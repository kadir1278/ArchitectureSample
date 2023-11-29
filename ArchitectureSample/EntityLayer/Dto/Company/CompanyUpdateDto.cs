using EntityLayer.Base;

namespace EntityLayer.Dto.Company
{
    public class CompanyUpdateDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
