using System.Security.Claims;

namespace CoreLayer.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(x => claims.Add(new Claim(type: ClaimTypes.Role, x)));
        }
    }
}
