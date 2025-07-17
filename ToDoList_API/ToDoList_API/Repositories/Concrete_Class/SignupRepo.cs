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
        public bool AddUser(SignUpAuth dto)
        {
            var search = _context.Users.FirstOrDefault(e => e.Email == dto.Email);
            if (dto.Password != dto.ConfirmPassword || search != null)
            {
                return false;
            }
            var newUser = new UserAuth
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Country = dto.Country,
                Password = dto.Password,
                ConfirmPassword = dto.ConfirmPassword,
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }
    }
}
