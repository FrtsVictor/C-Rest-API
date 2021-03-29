using System;

namespace Domain.API.Domain.Entities
{
    public class Client : Base
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Password { get; set; }        
        public bool IsActive { get; set; }
        public string Username { get; set; }
        
    }
}