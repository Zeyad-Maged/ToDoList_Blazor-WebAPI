using Microsoft.AspNetCore.Identity;
using ToDoList_API.Data;
using ToDoList_API.DTOs;
using ToDoList_API.Models;
using ToDoList_API.Repositories.Interface;

namespace ToDoList_API.Repositories.Concrete_Class
{
    public class SignupRepo : ISignupRepo
    {
        private readonly AppDbContext _context;

        public SignupRepo(AppDbContext context)
        {
            _context = context;
        }


        public bool RegisterUser(SignUpAuth dto)
        {
            var hasher = new PasswordHasher<UserAuth>();

            var exists = _context.Users.Any(e => e.Email == dto.Email);
            if (exists || dto.Password != dto.ConfirmPassword)
                return false;

            var user = new UserAuth
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Country = dto.Country,
                Password = hasher.HashPassword(null, dto.Password),
            };

            user.ConfirmPassword = dto.ConfirmPassword;

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
