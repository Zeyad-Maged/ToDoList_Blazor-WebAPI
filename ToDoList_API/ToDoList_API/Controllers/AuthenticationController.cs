using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList_API.DTOs;
using ToDoList_API.Repositories.Interface;

namespace ToDoList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginRepo _loginRepo;
        private readonly ISignupRepo _signupRepo;
        public AuthenticationController(ILoginRepo loginRepo, ISignupRepo signupRepo)
        {
            _loginRepo = loginRepo;
            _signupRepo = signupRepo;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginAuth dto)
        {
            var search = _loginRepo.IsValidUser(dto);
            if (search != 0)
            {
                return Ok(new { UserAuthId = search });
            }
            return Unauthorized("Invalid credentials");
        }
        [HttpPost("signup")]
        public IActionResult Signup(SignUpAuth dto)
        {
            if (_signupRepo.AddUser(dto))
            {
                return Created();
            }
            return BadRequest("Signup failed");
        }
    }
}
