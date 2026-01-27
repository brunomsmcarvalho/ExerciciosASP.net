using Microsoft.AspNetCore.Mvc;

namespace Exercicio5ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Servicos()
        {
            return View();
        }
        public IActionResult Portefolio()
        {
            return View();
        }
    }
}
