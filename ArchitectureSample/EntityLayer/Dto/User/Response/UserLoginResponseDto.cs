using CoreLayer.DataAccess.Abstract;
using CoreLayer.Entity.Dtos;

namespace EntityLayer.Dto.User.Response
{
    public record UserLoginResponseDto : IDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public IEnumerable<OperationClaimDto> OperationClaimDtos { get; set; }
    }
}
