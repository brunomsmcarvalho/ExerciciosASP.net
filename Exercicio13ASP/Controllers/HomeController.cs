using Exercicio13ASP.Data;
using Exercicio13ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Exercicio13ASP.Controllers
{
    public class HomeController : Controller
    {
        //aceder à base de dados
        private readonly DbTurismoContext _context;

        public HomeController(DbTurismoContext context)
        {
            //faz a ligaçao â base de dados
            _context = context;
        }

        public IActionResult Index()
        {
            // = a fazer select * from [....] traduzido pela EF fica var paginaHome = _context.Apresentacao.FirstOrDefault(m => m.Pagina == "Home");
            //vai á tabela e faz um select á tabela com a coluna pagina e encontra a página home
            var paginaHome = _context.Apresentacao.FirstOrDefault(m => m.Pagina == "Home");

            if (paginaHome == null)
            {
            return NotFound();
            }
            //envia a pagina para a view
            return View(paginaHome);
        }

        public IActionResult Segmentos()
        {
            var segmentos = _context.Segmentos.ToList();

            return View(segmentos);
        }

        public IActionResult Destinos(int id) //id do segmento
        {
            var segmento = _context.Segmentos.FirstOrDefault(s => s.Id == id);
            ViewBag.SegmentoNome = segmento != null ? segmento.SegmentoNome : "Segmento Desconecido";

            var destinos = _context.Destinos.Where(d => d.SegmentosId == id).ToList();
            return View(destinos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
