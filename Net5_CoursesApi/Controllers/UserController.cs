using Courses.Models.Users;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModelInput loginViewModelInput)
        {
            return Created("", loginViewModelInput);
        }


    }
}