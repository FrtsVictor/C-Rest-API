using System.ComponentModel.DataAnnotations;

namespace App.Models.Users
{
    public class UpdateUserViewModel
    {

        [Required(ErrorMessage = "Password needed")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email needed")]   
        public string Email { get; set; }

        [Required(ErrorMessage = "Name needed")]   
        public string Name { get; set; }
    }
}