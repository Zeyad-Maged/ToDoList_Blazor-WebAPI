using Microsoft.EntityFrameworkCore;
using ToDoList_API.Models;

namespace ToDoList_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAuth>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
        public DbSet<TodoItem> todoItems { get; set; }
        public DbSet<UserAuth> Users { get; set; }
    }
}
