using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.User.Response
{
    public record UserAddResponseDto : IDto
    {
        public string Username { get; set; }

        public UserAddResponseDto(string username)
        {
            Username = username;
        }
    }
}
