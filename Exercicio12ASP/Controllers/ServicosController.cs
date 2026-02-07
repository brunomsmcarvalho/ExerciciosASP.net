using Microsoft.AspNetCore.Mvc;

namespace Exercicio12ASP.Controllers
{
    public class ServicosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manutencao()
        {
            return View();
        }

        public IActionResult Desenvolvimento()
        {
            return View();
        }

        public IActionResult Seguranca()
        {
            return View();
        }
    }
}
