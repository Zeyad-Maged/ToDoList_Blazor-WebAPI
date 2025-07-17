using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList_API.DTOs;
using ToDoList_API.Repositories.Interface;

namespace ToDoList_API.Controllers
{
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
        public IActionResult GetTaskById(int Id)
        {
            var get = _repo.GetTaskById(Id);
            if (get == null)
                return NotFound();

            return Ok(get);
        }

        [HttpGet("GetAllTasks")]
        public IActionResult GetAllTasks(int UserAuthId) 
        {
            var getall = _repo.GetAllTasks(UserAuthId);
            if (getall == null)
                return NotFound();

            return Ok(getall);
        }
        [HttpPost("AddTask")]
        public IActionResult AddTask(CreateTodoDto dto, int UserAuthId) 
        {
            var add = _repo.AddTask(dto, UserAuthId);
            if (!add)
            {
                return NotFound("User Not Found");
            }
            return Created();
        }
        [HttpPut("UpdateTask/{Id}")]
        public IActionResult UpdateTask(UpdateTodoDto dto, int Id)
        {
            var update = _repo.UpdateTask(dto, Id);
            if(update == false)
                return NotFound();
            return Ok(update);
        }
        [HttpDelete("DeleteTask/{Id}")]
        public IActionResult DeleteTask(int Id)
        {
            var delete = _repo.DeleteTask(Id);
            if(delete == false)
                return NotFound();
            return Ok();
        }
    }
}
