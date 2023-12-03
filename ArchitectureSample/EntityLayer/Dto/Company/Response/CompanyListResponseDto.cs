using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.Company.Response
{
    public record CompanyListResponseDto : IDto
    {
        public string Name { get; set; }

        public CompanyListResponseDto(string name)
        {
            Name = name;
        }
    }
}
