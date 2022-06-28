using JWTToken.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTToken.CreateToken
{
    public class CreateJwtToken
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        public CreateJwtToken(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager; 
        }
        public JwtSecurityToken GetToken(List<Claim> claims)
        {
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var token = new JwtSecurityToken(
                 signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddDays(1),
                claims: claims
                );
            return token;
        }
    }
}
