using Common.Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common.Core.Secure.Jwt
{
    public static class TokenGenerator
    {
        public static string CreateToken(User user, string role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role)
            };
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes("RAUbe3TPYcBZoPqChkrD"));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);
            JwtSecurityToken token = new(
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds,
                issuer: "comparAcademy",
                audience: "comparAcademy"
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
