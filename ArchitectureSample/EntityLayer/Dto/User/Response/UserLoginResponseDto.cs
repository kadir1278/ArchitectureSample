using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.User.Response
{
    public record UserLoginResponseDto : IDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
