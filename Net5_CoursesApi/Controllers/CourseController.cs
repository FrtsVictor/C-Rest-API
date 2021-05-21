using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net5_CoursesApi.Models.Course;
using System.Security.Claims;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace Net5_CoursesApi.Controllers
{
    [Route("api/v1/curso")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        [SwaggerResponse(statusCode: 200, description: "Success!", Type = typeof(CreateCourseViewModel))]
        [SwaggerResponse(statusCode: 400, description: "Invalid fields.", Type = typeof(CreateCourseViewModel))]
        [SwaggerResponse(statusCode: 500, description: "Internal server error.", Type = typeof(CreateCourseViewModel))]
        public async Task<IActionResult> CreateCourse (CreateCourseViewModel createCourseViewModel)
        {
            var userLogin = int.Parse(User.FindFirst( u => u.Type == ClaimTypes.NameIdentifier)?.Value);
            
            return Created("", createCourseViewModel);
        }
        
        [HttpGet]
        [Route("")]
        [SwaggerResponse(statusCode: 200, description: "Sucess!", Type = typeof(CreateCourseViewModel))]
        [SwaggerResponse(statusCode: 500, description: "Internal server error.", Type = typeof(CreateCourseViewModel))]
        public async Task<IActionResult> GetAllCourses ()
        {
            var userEmail = User.FindFirst( u => u.Type == ClaimTypes.Email)?.Value;

            var courses = new List<CourseViewModelOutput>();
            courses.Add(new CourseViewModelOutput
            {   
                Category = "Teste Category",
                Name = "TesteName",
                Description = userEmail.ToString() ?? "xd"
            });

            return Ok(courses);            
        }

    }
}