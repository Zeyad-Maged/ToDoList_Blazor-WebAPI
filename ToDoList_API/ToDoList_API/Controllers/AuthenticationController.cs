using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList_API.DTOs;
using ToDoList_API.Repositories.Interface;

namespace ToDoList_API.Controllers
{
    [AllowAnonymous] // Important: Login & Signup should be open
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
        public IActionResult Login([FromBody] LoginAuth dto)
        {
            var result = _loginRepo.ValidateUser(dto);
            if (result == null)
                return Unauthorized("Invalid credentials");

            return Ok(result);
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] SignUpAuth dto)
        {
            if (!_signupRepo.RegisterUser(dto))
                return BadRequest("Signup failed");

            return StatusCode(201); // Created
        }
    }
}
