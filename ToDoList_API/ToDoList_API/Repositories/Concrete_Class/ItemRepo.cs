using Microsoft.IdentityModel.Tokens;
using ToDoList_API.Data;
using ToDoList_API.DTOs;
using ToDoList_API.Models;
using ToDoList_API.Repositories.Interface;

namespace ToDoList_API.Repositories.Concrete_Class
{
    public class ItemRepo : IItemRepo
    {
        private readonly AppDbContext _context;

        public ItemRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddTask(CreateTodoDto dto, int UserAuthId)
        {
            var search = _context.Users.FirstOrDefault(i => i.Id == UserAuthId);
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
                UserAuthId = UserAuthId,
            };
            _context.todoItems.Add(task);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTask(int id)
        {
            var search = _context.todoItems.FirstOrDefault(i => i.Id == id);
            if (search == null)
                return false;
            _context.todoItems.Remove(search);
            _context.SaveChanges();
            return true;
        }

        public List<TodoItem> GetAllTasks(int UserAuthId)
        {
            var lis = _context.todoItems
                .Where(i => i.UserAuthId == UserAuthId)
                .ToList();
            if(lis.IsNullOrEmpty())
                return null;
            return lis;
        }

        public TodoDto GetTaskById(int Id)
        {
            var search = _context.todoItems.FirstOrDefault(i => i.Id == Id);
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

        public bool UpdateTask(UpdateTodoDto dto, int Id)
        {
            var search = _context.todoItems.FirstOrDefault(i => i.Id == Id);
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
    }
}
