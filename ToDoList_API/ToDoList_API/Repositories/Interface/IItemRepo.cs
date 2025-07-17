using ToDoList_API.DTOs;
using ToDoList_API.Models;

namespace ToDoList_API.Repositories.Interface
{
    public interface IItemRepo
    {
        bool AddTask(CreateTodoDto dto);
        bool UpdateTask(UpdateTodoDto dto, int Id);
        bool DeleteTask(int id);
        TodoDto GetTaskById(int Id);
        List<TodoItem> GetAllTasks();
    }
}
