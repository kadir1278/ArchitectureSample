using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.Company.Response
{
    public record CompanyGetByIdResponseDto : IDto
    {
        public string Name { get; set; }

        public CompanyGetByIdResponseDto(string name)
        {
            Name = name;
        }
    }
}
