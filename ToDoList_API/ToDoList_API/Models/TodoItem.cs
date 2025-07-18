using System.ComponentModel.DataAnnotations;

namespace ToDoList_API.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required]
        public string Priority { get; set; } = "Medium";

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        public bool IsArchived { get; set; }
        public Guid UserAuthId { get; set; }
        public UserAuth UserAuth { get; set; }
    }
}
