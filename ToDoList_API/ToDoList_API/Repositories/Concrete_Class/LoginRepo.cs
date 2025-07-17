using ToDoList_API.Data;
using ToDoList_API.DTOs;
using ToDoList_API.Repositories.Interface;

namespace ToDoList_API.Repositories.Concrete_Class
{
    public class LoginRepo : ILoginRepo
    {
        private readonly AppDbContext _context;
        public LoginRepo(AppDbContext context)
        {
            _context = context;
        }
        public int IsValidUser(LoginAuth dto)
        {
            var search = _context.Users.FirstOrDefault(user => user.Email == dto.Email && user.Password == dto.Password);
            if (search == null)
            {
                return 0;
            }
            return search.Id;
        }
    }
}
