using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.Company.Request
{
    public record CompanyAddRequestDto:IDto
    {
        public string Name { get; set; }

        public CompanyAddRequestDto(string name)
        {
            Name = name;
        }
    }
}
