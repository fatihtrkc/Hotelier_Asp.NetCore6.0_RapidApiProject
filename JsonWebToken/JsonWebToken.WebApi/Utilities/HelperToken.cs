using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JsonWebToken.WebApi.Utilities
{
    internal static class HelperToken
    {
        internal static string Add()
        {
            var bytes = Encoding.UTF32.GetBytes("aspnetcorewebapi");

            SymmetricSecurityKey key = new(bytes);

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(issuer: "https://localhost", audience: "https://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new();

            return handler.WriteToken(token);
        }

        internal static string AddForAdmin()
        {
            var bytes = Encoding.UTF32.GetBytes("aspnetcorewebapi");

            SymmetricSecurityKey key = new(bytes);

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            IEnumerable<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Customer")
            };

            JwtSecurityToken token = new(issuer: "https://localhost", audience: "https://localhost", claims: claims, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new();

            return handler.WriteToken(token);
        }
    }
}
