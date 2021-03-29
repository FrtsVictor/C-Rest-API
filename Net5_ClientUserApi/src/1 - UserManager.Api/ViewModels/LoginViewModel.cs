using System.ComponentModel.DataAnnotations;

namespace UserManager.Api.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login can't be empty")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]
        public string Password { get; set; } 
               
    }
}