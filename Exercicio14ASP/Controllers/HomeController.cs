using Exercicio14ASP.Data;
using Exercicio14ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exercicio14ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbMiniCMSContext _context;
        public HomeController(ILogger<HomeController> logger, DbMiniCMSContext context)
        {
            _logger = logger;
            _context = context;
        }
        //private readonly DbMiniCMSContext _context;
        //public HomeController(DbMiniCMSContext context)
        //{
        // _context = context;
        //}
        public IActionResult Index()
        {
            // recuperar da BD miniCMS da tabela Conteudo, o registo cujo campo Pagina = "Home"
            var paginaHome = _context.Conteudos.FirstOrDefault(m => m.Pagina == "Home");
            if (paginaHome == null)
            {
                return NotFound();
            }
            return View(paginaHome);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
