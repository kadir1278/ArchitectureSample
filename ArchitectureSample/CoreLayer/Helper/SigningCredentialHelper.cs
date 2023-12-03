using Microsoft.IdentityModel.Tokens;

namespace CoreLayer.Helper
{
    public class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(key: securityKey, algorithm: SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
