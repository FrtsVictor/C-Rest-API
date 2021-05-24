namespace Infra.Entities
{
    public class User : Base
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}