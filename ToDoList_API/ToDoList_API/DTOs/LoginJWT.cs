using System.ComponentModel.DataAnnotations;

namespace ToDoList_API.DTOs
{
    public class LoginJWT
    {
        public Guid? UserAuthId { get; set; }
        public string? Email { get; set; }
        public string? AccessToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
