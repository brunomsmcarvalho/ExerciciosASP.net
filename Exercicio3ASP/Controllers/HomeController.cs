using Microsoft.AspNetCore.Mvc;

namespace Exercicio3ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public string Sobre()
        {
            //Em vez de me retornar uma view retorna uma string simples
            return $"Exercício ASP.NET Core MVC - Sobre {DateTime.Now}"; // Retorna uma string simples
            // Com o simbolo do $ podemos inserir variaveis dentro da string
        }
    }
}
