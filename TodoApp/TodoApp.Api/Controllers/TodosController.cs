using System.Threading.Tasks;
using System.Web.Http;
using TodoApp.Data.Repositories;

namespace TodoApp.Api.Controllers
{
    public class TodosController : ApiController
    {
        private readonly ITodoRepository _todoRepository;

        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTodos()
        {
            return Ok(await _todoRepository.GetTodosAsync());
        }
    }
}
