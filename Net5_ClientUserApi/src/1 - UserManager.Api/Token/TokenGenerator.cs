using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace UserManager.Api.Token
{
    public class TokenGenerator : ITokenGenerator
    {

        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
                _configuration = configuration;
        }

        public string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler(); //quem manunseia o token

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]); //pego a key pra gerar o token

            var tokenDescriptor = new SecurityTokenDescriptor //funciona como o payload
            {
                Subject = new ClaimsIdentity(new Claim[] //dados do usuario
                {
                    new Claim(ClaimTypes.Name, _configuration["Jwt:Login"]),
                    new Claim(ClaimTypes.Role, "User"),
                }),
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"])),

                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); //gera o token

            return tokenHandler.WriteToken(token); //assina o token e entrega pro usuario
        }

        
    }
}