using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using TodoApp.Data.Models;
using TodoApp.Data.Repositories;

namespace TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<ActionResult> Index()
        {
            try
            {
                var todos = await _todoRepository.GetTodosAsync();
                ViewBag.Todos = todos;
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Index(Todo todo)
        {
            if(!ModelState.IsValid)
            {
                return View(todo);
            }
            try
            {
                await _todoRepository.AddTodoAsync(todo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<ActionResult> ToggleItem(int id)
        {
            try
            {
                var todoItem = await _todoRepository.FindTodByIdAsync(id);
                //if(todoIem==null)
                //{

                //}
                todoItem.Completed=!todoItem.Completed;
                await _todoRepository.UpdateTodoAsync(todoItem);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                var todoItem = await _todoRepository.FindTodByIdAsync(id);
                //if(todoIem==null)
                //{

                //}
                await _todoRepository.DeleteTodoAsync(todoItem);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}