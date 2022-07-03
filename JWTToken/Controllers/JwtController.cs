using JWTToken.Context;
using JWTToken.CreateToken;
using JWTToken.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Domain.Entities;
using ShoppingList.Infrastructure.Persistence.Contexts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JWTToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {

        #region Members
        List<Claim> claims = new List<Claim>();
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        CreateJwtToken createJwtToken;
        private readonly MyDbContext _myDbContext;
        #endregion
        #region Constructor
        public JwtController(List<Claim> claims, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, CreateJwtToken createJwtToken, MyDbContext myDbContext)
        {
            this.claims = claims;
            _userManager = userManager;
            _roleManager = roleManager;
            this.createJwtToken = createJwtToken;
            _myDbContext = myDbContext;
        }
        #endregion
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null) throw new Exception("User boş olamaz.");
            var result = await _userManager.CheckPasswordAsync(user, login.Password);
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                claims.Add(new Claim(ClaimTypes.Name, user.Email));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                var token = createJwtToken.GetToken(claims);
                var handler = new JwtSecurityTokenHandler();
                string jwt = handler.WriteToken(token);
                return Ok(new
                {
                    token = jwt,
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

    }
}
