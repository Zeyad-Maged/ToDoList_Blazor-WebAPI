using ToDoList_API.DTOs;
using ToDoList_API.Models;

namespace ToDoList_API.Repositories.Interface
{
    public interface IItemRepo
    {
        public bool AddTask(CreateTodoDto dto, int UserAuthId);
        public bool UpdateTask(UpdateTodoDto dto, int Id);
        public bool DeleteTask(int id);
        public TodoDto GetTaskById(int Id);
        public List<TodoItem> GetAllTasks(int UserAuthId);
    }
}
