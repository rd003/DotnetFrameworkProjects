using System.Threading.Tasks;
using System.Web.Http;

namespace TodoApp.Api.Controllers
{
    public class TodosController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetTodos()
        {
            return Ok("Todos.....");
        }
    }
}
