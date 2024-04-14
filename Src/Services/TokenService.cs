using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using courses_dotnet_api.Src.DTO;
using courses_dotnet_api.Src.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace courses_dotnet_api.Src.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            //encoding _key by SymmetricSecurityKey by UTF8 where obtain the bytes
            _key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    configuration["Tokenkey"] ?? throw new InvalidOperationException("Token key not found")
                )
            );
        }

        public string CreateToken(AccountDTO accountDTO)
        {
            var claims = new List<Claim> { new(JwtRegisteredClaimNames.NameId, accountDTO.Rut) };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}