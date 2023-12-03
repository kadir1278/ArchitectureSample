using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.Company.Response
{
    public record CompanyAddResponseDto:IDto
    {
        public string Name { get; set; }

        public CompanyAddResponseDto(string name)
        {
            Name = name;
        }
    }
}
