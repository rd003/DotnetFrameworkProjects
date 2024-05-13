using System.Data.Entity;

namespace TodoApp.Data.Models
{
    public class ApplicationDbContext:DbContext
    {
        // how to get connection string
        public ApplicationDbContext():base("default")
        {
            
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
