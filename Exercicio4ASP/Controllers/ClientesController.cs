using Microsoft.AspNetCore.Mvc;

namespace Exercicio4ASP.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
