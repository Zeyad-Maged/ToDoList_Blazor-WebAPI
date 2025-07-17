using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList_API.DTOs
{
    public class LoginAuth
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
