using System.ComponentModel.DataAnnotations;

namespace Courses.Models.Users
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "Login needed to access your account")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password needed to access your account")]
        public string Password { get; set; }        

        
    }
}