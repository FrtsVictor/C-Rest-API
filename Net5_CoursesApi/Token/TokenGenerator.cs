using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Net5_CoursesApi.Models.Users;

namespace Net5_CoursesApi.Token
{
    public class TokenGenerator
    {
        public string GenerateToken(UserViewModelOutput user)
        {
            var secret = Encoding.ASCII.GetBytes("aWYgdSBjYW4gcmVhZCB0aGlzLCB1IGFyZW4ndCBoYWNrZXIgOnA=");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)  
                };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return token;
        }

        public UserViewModelOutput createTesteUser()
        {
            return new UserViewModelOutput()
            {
                Id = 123,
                Email = "victor@victor",
                Login = "loginTest",
                Password = "123321"
            };
        }

    }
}