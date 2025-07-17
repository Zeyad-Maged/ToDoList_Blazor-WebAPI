using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList_API.Models
{
    public class UserAuth
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Country { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string? ConfirmPassword { get; set; }
        public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    }
}
