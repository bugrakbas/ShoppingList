using JWTToken.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTToken.Context
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<LoginModel> LoginModels { get; set; }
    }
}
