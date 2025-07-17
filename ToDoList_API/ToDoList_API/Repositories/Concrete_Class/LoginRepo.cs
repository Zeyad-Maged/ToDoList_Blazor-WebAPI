using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList_API.Data;
using ToDoList_API.DTOs;
using ToDoList_API.Models;
using ToDoList_API.Repositories.Interface;

namespace ToDoList_API.Repositories.Concrete_Class
{
    public class LoginRepo : ILoginRepo
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginRepo(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public LoginJWT ValidateUser(LoginAuth dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null)
                return null;

            var hasher = new PasswordHasher<UserAuth>();
            var result = hasher.VerifyHashedPassword(null, user.Password, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                return null;

            var key = Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email),
                    // new Claim(ClaimTypes.Role, "User") // Optional: if using roles
                }),
                Expires = DateTime.UtcNow.AddYears(100),
                Issuer = _configuration["JwtConfig:Issuer"],
                Audience = _configuration["JwtConfig:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);

            return new LoginJWT
            {
                UserAuthId = user.Id,
                Email = user.Email,
                AccessToken = accessToken,
                ExpiresIn = (int)(tokenDescriptor.Expires.Value - DateTime.UtcNow).TotalSeconds
            };
        }
    }
}
