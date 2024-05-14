using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Data.Models;

namespace TodoApp.Data.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodosAsync();
    }

    public class TodoRepository : ITodoRepository
    {
        public async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            return await Task.FromResult(Enumerable.Empty<Todo>());
        }
    }
}
