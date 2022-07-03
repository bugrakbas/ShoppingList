using Microsoft.AspNetCore.Identity;

namespace JWTToken.Models
{
    public class AppUser : IdentityUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
