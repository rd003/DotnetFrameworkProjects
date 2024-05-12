using System.Data.Entity;

namespace TodoApp.Data.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Todo> Todos { get; set; }
    }
}
