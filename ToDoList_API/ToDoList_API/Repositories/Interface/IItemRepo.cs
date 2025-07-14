using ToDoList_API.DTOs;
using ToDoList_API.Models;

namespace ToDoList_API.Repositories.Interface
{
    public interface IItemRepo
    {
        public void AddTask(CreateTodoDto dto);
        public bool UpdateTask(UpdateTodoDto dto, int Id);
        public bool DeleteTask(int id);
        public TodoDto GetTaskById(int Id);
        public List<TodoItem> GetAllTasks();
    }
}
