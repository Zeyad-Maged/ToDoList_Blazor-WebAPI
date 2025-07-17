using ToDoList_API.DTOs;
using ToDoList_API.Models;

namespace ToDoList_API.Repositories.Interface
{
    public interface IItemRepo
    {
        bool AddTask(CreateTodoDto dto);
        bool UpdateTask(UpdateTodoDto dto, Guid Id);
        bool DeleteTask(Guid id);
        TodoDto GetTaskById(Guid Id);
        List<TodoItem> GetAllTasks();
    }
}
