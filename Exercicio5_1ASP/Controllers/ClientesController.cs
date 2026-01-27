using Microsoft.AspNetCore.Mvc;

namespace Exercicio5_1ASP.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
