using System;
using Microsoft.AspNetCore.Mvc;
using UserManager.Api.Token;
using UserManager.Api.Utils;
using UserManager.Api.ViewModels;
using Microsoft.Extensions.Configuration;

namespace UserManager.Api.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticationController(IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Route("/api/v1/authentication/login")]
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                var tokenLogin = _configuration["Jwt:Login"];
                var tokenPassword = _configuration["Jwt:Password"];

                if(loginViewModel.Login == tokenLogin && loginViewModel.Password == tokenPassword)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "User authenticated",
                        Sucess = true,
                        Data = new 
                        {
                            Token = _tokenGenerator.GenerateToken(),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                else
                {
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
                }
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

    }
}