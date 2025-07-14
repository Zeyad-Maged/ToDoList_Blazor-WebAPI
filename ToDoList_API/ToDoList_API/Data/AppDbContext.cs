using Microsoft.EntityFrameworkCore;
using ToDoList_API.Models;

namespace ToDoList_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<TodoItem> todoItems { get; set; }
    }
}
