using System.Web.Mvc;

namespace TodoApp.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("TodoApis");
        }
    }
}