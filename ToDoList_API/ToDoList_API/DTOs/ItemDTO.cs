using System.ComponentModel.DataAnnotations;
using ToDoList_API.Models;

namespace ToDoList_API.DTOs
{
    public class CreateTodoDto
    {   
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required]
        public string Priority { get; set; } = "Medium";

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        public bool IsArchived { get; set; }
    }

    public class UpdateTodoDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required]
        public string Priority { get; set; } = "Medium";

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsArchived { get; set; }
    }

    public class TodoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserAuthId { get; set; }
    }

}
