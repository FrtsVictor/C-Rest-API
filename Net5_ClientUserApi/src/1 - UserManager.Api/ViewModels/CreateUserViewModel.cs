using System.ComponentModel.DataAnnotations;

namespace UserManager.Api.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Name mandatory")]
        [MinLength(3, ErrorMessage = "Name should have minimun of 3 characters")]
        [MaxLength(80, ErrorMessage = "Name should have maximun 80 characters")]
        public string Name { get; private set; }       

        [Required(ErrorMessage = "Email mandatory")]
        [MinLength(10, ErrorMessage = "Email  should have minimun of 10 characters")]
        [MaxLength(80, ErrorMessage = "Email  should have maximun 80 characters")]
        public string Email { get; private set; }
        
        [Required(ErrorMessage = "Password mandatory")]
        [MinLength(6, ErrorMessage = "Password should have minimun of 6 characters")]
        [MaxLength(80, ErrorMessage = "Password should have maximun 80 characters")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "O email informado não é válido.")]
        public string Password { get; private set; }

        [Required(ErrorMessage = "Name mandatory")]
        [MinLength(5, ErrorMessage = "Name should have minimun of 5 characters")]
        [MaxLength(30, ErrorMessage = "Name should have maximun 30 characters")]
        public string Username { get; private set; }
        
    }
}