using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using TodoApp.Data.Models;
using TodoApp.Data.Repositories;

namespace TodoApp.Api.Controllers
{
    public class TodosController : ApiController
    {
        private readonly ITodoRepository _todoRepository;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTodos()
        {
            try
            {
                Logger.Info("Fetching todos list");
                return Ok(await _todoRepository.GetTodosAsync());
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);

            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTodo(int id)
        {
            try
            {
                var todo = await _todoRepository.FindTodByIdAsync(id);
                if(todo == null) 
                {
                    return NotFound();
                }
                return Ok(todo);

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateTodo(Todo todo)
        {
            try
            {
                await _todoRepository.AddTodoAsync(todo);
                return Created(nameof(CreateTodo),todo);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateTodo(int id,[FromBody]Todo todo)
        {
            try
            {
                if(todo.Id!=id)
                {
                    return BadRequest("id in url and body does not match.");
                }
                var exisitingTodo = await _todoRepository.FindTodByIdAsync(id);
                if (exisitingTodo == null)
                {
                    return NotFound();
                }
                await _todoRepository.UpdateTodoAsync(todo);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteTodo(int id)
        {
            try
            {
                var todo = await _todoRepository.FindTodByIdAsync(id);
                if (todo == null)
                {
                    return NotFound();
                }
                await _todoRepository.DeleteTodoAsync(todo);
                return StatusCode(HttpStatusCode.NoContent); // returns 204
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
