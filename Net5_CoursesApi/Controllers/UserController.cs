using Courses.Filters;
using Courses.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Net5_CoursesApi.Token;
using Swashbuckle.AspNetCore.Annotations;
namespace Courses.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [SwaggerResponse(statusCode: 200, description: "Authenticated!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Invalid fields.", Type = typeof(ValidateFields))]
        [SwaggerResponse(statusCode: 500, description: "Internal server error.", Type = typeof(GenericError))]
        [CustomValidateModelState]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
           var tokenGenerator = new TokenGenerator();
           var user = tokenGenerator.createTesteUser();
           string token =tokenGenerator.GenerateToken(user);

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
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            return Created("", registerViewModelInput);
        }

    }
}