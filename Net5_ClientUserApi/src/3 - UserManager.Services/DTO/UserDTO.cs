namespace UserManager.Services.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }               
        public string Name { get;  set; }       
        public string Email { get; set; }
        public string Password { get;  set; }
        public string Username { get;  set; }

        public UserDTO()
        {}
        public UserDTO(long id, string name, string email, string password, string username)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Username = username;
        }
    }
}