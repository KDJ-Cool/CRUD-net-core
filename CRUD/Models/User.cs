using Microsoft.AspNetCore.Identity;

namespace CRUD.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        LowUser,
        HighUser
    }
}