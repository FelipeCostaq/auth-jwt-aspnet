using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthFinance.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthFinance.Services
{
    public class TokenService
    {
        private readonly string _key;

        public TokenService(string key)
        {
            _key = key;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "AuthFinance",
                audience: "AuthFinance",
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
