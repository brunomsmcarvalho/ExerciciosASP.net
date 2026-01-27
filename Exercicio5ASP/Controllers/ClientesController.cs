using Microsoft.AspNetCore.Mvc;

namespace Exercicio5ASP.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
