using Exercicio7ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exercicio7ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           return View();
        }

        public IActionResult Form1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form1(string utilizador, string password, string lembrar)
        {
            //Cliente cliente = new Cliente();
            //cliente.Nome = utilizador;
            //cliente.Password = password;
            //ou ..
            Cliente cliente = new Cliente { Nome = utilizador, Password = password };
            // Codigo para usar as variaveis 'utilizador', 'password' e 'lembrar'
            // return View("Index");
            return View("Dados_recebidos", cliente); // Passa o objeto 'cliente' para a View 'Dados_recebidos'
        }
        // Fim Form1

        public IActionResult Form2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form2(IFormCollection formCollection)
        {
            string nome = formCollection["Nome"];
            string apelido = formCollection["Apelido"];
            string email = formCollection["Email"];
            string mensagem = formCollection["Mensagem"];
            Cliente cliente = new Cliente { Nome = nome, Apelido = apelido, Email = email, Mensagem = mensagem };

            return View("Dados_recebidos", cliente);
        }
        // Fim Form_2 
        public IActionResult Form3()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Form3(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                return View("Dados_recebidos", cliente);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
