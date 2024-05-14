using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TodoApp.Data.Models;

namespace TodoApp.Data.Repositories
{
    public interface ITodoRepository
    {
        Task<Todo> AddTodoAsync(Todo todo);
        Task DeleteTodoAsync(Todo todo);
        Task<Todo> FindTodByIdAsync(int id);
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<Todo> UpdateTodoAsync(Todo todo);
    }

    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;
        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Todo>> GetTodosAsync() =>
             await _context.Todos.AsNoTracking().ToListAsync();

        public async Task<Todo> FindTodByIdAsync(int id) => await _context.Todos.AsNoTracking().FirstOrDefaultAsync(todo => todo.Id == id);

        public async Task DeleteTodoAsync(Todo todo)
        {
            _context.Entry(todo).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> AddTodoAsync(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> UpdateTodoAsync(Todo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return todo;
        }

    }
}
