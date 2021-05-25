using System.ComponentModel.DataAnnotations;

namespace Courses.Models.Users
{
    public class RegisterViewModelInput
    {
        [Required(ErrorMessage = "Login needed to register")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password needed to register")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email needed to register")]   
        public string Email { get; set; }

        [Required(ErrorMessage = "Name needed to register")]   
        public string Name { get; set; }
        
    }
}