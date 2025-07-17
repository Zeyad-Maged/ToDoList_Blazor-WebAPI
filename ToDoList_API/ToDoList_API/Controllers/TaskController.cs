using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList_API.DTOs;
using ToDoList_API.Repositories.Interface;

namespace ToDoList_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IItemRepo _repo;

        public TaskController(IItemRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{Id}")]
        public IActionResult GetTaskById(Guid Id)
        {
            var task = _repo.GetTaskById(Id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpGet("GetAllTasks")]
        public IActionResult GetAllTasks()
        {
            var tasks = _repo.GetAllTasks();
            if (tasks == null || !tasks.Any())
                return NotFound();

            return Ok(tasks);
        }

        [HttpPost("AddTask")]
        public IActionResult AddTask([FromBody] CreateTodoDto dto)
        {
            var added = _repo.AddTask(dto);
            if (!added)
                return NotFound("User not found");

            return StatusCode(201);
        }

        [HttpPut("UpdateTask/{Id}")]
        public IActionResult UpdateTask([FromBody] UpdateTodoDto dto, Guid Id)
        {
            var updated = _repo.UpdateTask(dto, Id);
            if (!updated)
                return NotFound();

            return Ok("Task updated");
        }

        [HttpDelete("DeleteTask/{Id}")]
        public IActionResult DeleteTask(Guid Id)
        {
            var deleted = _repo.DeleteTask(Id);
            if (!deleted)
                return NotFound();

            return Ok("Task deleted");
        }
    }
}
