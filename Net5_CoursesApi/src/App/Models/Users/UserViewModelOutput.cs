namespace Net5_CoursesApi.Models.Users
{
    public class UserViewModelOutput
    {
        public int Id { get; set; }
        public string Username { get; set; }        
        public string Password { get; set; }        
        public string Email { get; set; }
        public string Name { get; set; } 
        public string Login { get; set; }         
    }
}