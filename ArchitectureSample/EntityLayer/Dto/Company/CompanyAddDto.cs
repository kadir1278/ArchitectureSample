using EntityLayer.Base;

namespace EntityLayer.Dto.Company
{
    public class CompanyAddDto : BaseDto
    {
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Web { get; set; }
        public Guid ProjectOwnerId { get; set; }
    }
}
