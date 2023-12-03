using CoreLayer.Entity.Dtos;
using EntityLayer.Dto.Jwt;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User jwtUser, List<OperationClaimDto> operationClaims);
        bool CheckStatusJwt(string bearerToken, string nameIdentifier);

    }
}
