using Microsoft.AspNetCore.Mvc;

namespace Exercicio13ASP.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection formCollection)
        {
            string? user = formCollection["UserName"];
            string? pass = formCollection["Password"];
            // Define a sessão de login como "false" para indicar que o usuário não está autenticado
            HttpContext.Session.SetString("Login", "false");
            // Verifica se as credenciais são válidas (neste exemplo, apenas "admin" para ambos)
            if (user == "admin" && pass == "admin")
            {
                // Define a sessão de login como "true" para indicar que o usuário está autenticado
                HttpContext.Session.SetString("Login", "true");
                return RedirectToAction("Admin");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Admin()
        {
            var login = HttpContext.Session.GetString("Login");
            if (login == null)
            {
                return RedirectToAction("Index");
            }
            if (bool.Parse(login) == false)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

