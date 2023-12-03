using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.User.Request
{
    public record UserLoginRequestDto:IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
