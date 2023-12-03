using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.User.Response
{
    public record UserListResponseDto:IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string CompanyName { get; set; }

        public UserListResponseDto(string name, string surname, string username, string companyName)
        {
            Name = name;
            Surname = surname;
            Username = username;
            CompanyName = companyName;
        }
    }
}
