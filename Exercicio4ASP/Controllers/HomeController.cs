using Microsoft.AspNetCore.Mvc;

namespace Exercicio4ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //codigo C# para preparar dados para a View, se necessário

            return View();
        }
        //Home/Contato
        public IActionResult Contato()
        {
            return View();
        }

        //Home/Admin
        public IActionResult Admin()
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
