using BusinessLayer.Abstract;
using CoreLayer.Entity.Dtos;
using CoreLayer.Extensions;
using CoreLayer.Helper;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using EntityLayer.Dto.Jwt;
using EntityLayer.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace BusinessLayer.Concrete
{
    public class TokenHelper : ITokenHelper
    {
        private IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        //private DateTime _accessTokenExpiration;
        public TokenHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
        }


        public AccessToken CreateToken(User jwtUser, List<OperationClaimDto> operationClaims)
        {
            DateTime expires;
            var securityKey = EncryptionHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, jwtUser, signingCredentials, operationClaims, out expires);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = expires
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,
                                                        User jwtUser,
                                                        SigningCredentials signingCredentials,
                                                        List<OperationClaimDto> OperationClaim, out DateTime expires)
        {
            expires = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: expires,
                notBefore: DateTime.Now,
                claims: SetClaims(jwtUser, OperationClaim),
                signingCredentials: signingCredentials
                );
            return jwt;
        }


        private IEnumerable<Claim> SetClaims(User jwtUser, List<OperationClaimDto> operationClaim)
        {
            var claims = new List<Claim>();
            claims.AddRoles(operationClaim.Select(x => x.Name).ToArray());
            return claims;
        }
        public bool CheckStatusJwt(string bearerToken, string nameIdentifier)
        {
            try
            {
                var jwtToken = bearerToken.ToString().Replace("Bearer ", "");
                var tokenInfo = DecodeJwtToken(jwtToken);

                var deserialzeToken = JsonSerializer.Deserialize<List<ClaimDto>>(tokenInfo.Data);
                if (deserialzeToken.Count == 0 && deserialzeToken == null)
                    return false;

                var tokenDateTimeSeconds = Convert.ToInt32(deserialzeToken.Where(x => x.Type == "exp").FirstOrDefault().Value);
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(tokenDateTimeSeconds);
                var tokenExpirationDateTime = dateTimeOffset.LocalDateTime; // 05/12/2023 17.00

                if (Convert.ToDateTime(tokenExpirationDateTime) <= DateTime.Now)
                    return false;

                var tokenReconId = deserialzeToken.Where(x => x.Type.Contains("claims/nameidentifier")).FirstOrDefault().Value;
                if (tokenReconId != nameIdentifier)
                    return false;

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public IDataResult<string> DecodeJwtToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
            {
                return new ErrorDataResult<string>( "decode edilemedi");

            }
            var jwtToken = handler.ReadJwtToken(token);

            var claimValues = jwtToken.Claims.Select(c => new ClaimDto { Type = c.Type, Value = c.Value }).ToList();

            var json = JsonSerializer.Serialize(claimValues);

            return new SuccessDataResult<string>(json, "decode edildi");
        }
    }
}
