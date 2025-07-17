using Microsoft.IdentityModel.Tokens;
using ToDoList_API.Data;
using ToDoList_API.DTOs;
using ToDoList_API.Models;
using ToDoList_API.Repositories.Interface;
using System.Security.Claims;

namespace ToDoList_API.Repositories.Concrete_Class
{
    public class ItemRepo : IItemRepo
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemRepo(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool AddTask(CreateTodoDto dto)
        {
            int userId = GetUserId();
            var search = _context.Users.FirstOrDefault(i => i.Id == userId);
            if (search == null)
            {
                return false;
            }

            var task = new TodoItem
            {
                IsCompleted = false,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Title = dto.Title,
                Priority = dto.Priority,
                UserAuthId = userId,
            };

            _context.todoItems.Add(task);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTask(int id)
        {
            int userId = GetUserId();
            var search = _context.todoItems.FirstOrDefault(i => i.Id == id && i.UserAuthId == userId);
            if (search == null)
                return false;

            _context.todoItems.Remove(search);
            _context.SaveChanges();
            return true;
        }

        public List<TodoItem> GetAllTasks()
        {
            int userId = GetUserId();
            var list = _context.todoItems
                .Where(i => i.UserAuthId == userId)
                .ToList();

            return list ?? new List<TodoItem>();
        }

        public TodoDto GetTaskById(int id)
        {
            int userId = GetUserId();
            var search = _context.todoItems.FirstOrDefault(i => i.Id == id && i.UserAuthId == userId);
            if (search == null)
                return null;

            return new TodoDto
            {
                Title = search.Title,
                IsArchived = search.IsArchived,
                IsCompleted = search.IsCompleted,
                Description = search.Description,
                DueDate = search.DueDate,
                Priority = search.Priority,
            };
        }

        public bool UpdateTask(UpdateTodoDto dto, int id)
        {
            int userId = GetUserId();
            var search = _context.todoItems.FirstOrDefault(i => i.Id == id && i.UserAuthId == userId);
            if (search == null)
                return false;

            search.Description = dto.Description;
            search.DueDate = dto.DueDate;
            search.Title = dto.Title;
            search.Priority = dto.Priority;
            search.IsArchived = dto.IsArchived;
            search.IsCompleted = dto.IsCompleted;

            _context.todoItems.Update(search);
            _context.SaveChanges();
            return true;
        }

        private int GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null)
                throw new Exception("User is not authenticated.");

            return int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
