using System.ComponentModel.DataAnnotations;

namespace UserManager.Api.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Name mandatory")]
        [MinLength(3, ErrorMessage = "Name should have minimun of 3 characters")]
        [MinLength(80, ErrorMessage = "Name should have maximun 80 characters")]
        public string Name { get; private set; }       

        [Required(ErrorMessage = "Email mandatory")]
        [MinLength(3, ErrorMessage = "Email  should have minimun of 3 characters")]
        [MinLength(80, ErrorMessage = "Email  should have maximun 80 characters")]
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Username { get; private set; }
        
    }
}