using System;
using System.Threading.Tasks;
using App.Services;
using App.Token;
using AutoMapper;
using Courses.Filters;
using Courses.Models.Users;
using Infra.Entities;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Net5_CoursesApi.Token;
using Swashbuckle.AspNetCore.Annotations;


namespace Courses.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator ;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [SwaggerResponse(statusCode: 200, description: "Authenticated!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Invalid fields.", Type = typeof(ValidateFields))]
        [SwaggerResponse(statusCode: 500, description: "Internal server error.", Type = typeof(GenericError))]
        [CustomValidateModelState]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
           
           var user = _tokenGenerator.createTesteUser();
           string token = _tokenGenerator.GenerateToken(user);

            return Ok(new
            {
                Token = token,
                User = user
            });
        }

        [HttpPost]
        [SwaggerResponse(statusCode: 201, description: "Created!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Invalid fields.", Type = typeof(ValidateFields))]
        [SwaggerResponse(statusCode: 500, description: "Internal server error.", Type = typeof(GenericError))]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModelInput registerViewModelInput)
        {
            var user = new User();
            user.Email = registerViewModelInput.Email;
            user.Name = registerViewModelInput.Name;
            user.Username = registerViewModelInput.Username;
            user.Password = registerViewModelInput.Password;
            
            await _userService.Create(registerViewModelInput);
            return Created("", registerViewModelInput);
            
        }

    }
}