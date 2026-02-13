using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalFerias.Data;
using PortalFerias.Models;

namespace PortalFerias.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbPortalFeriasContext _context;

        public HomeController(DbPortalFeriasContext context)
        {
            _context = context;
        }

        // GET: Home/Index
        public async Task<IActionResult> Index()
        {
            var apresentacao = await _context.Apresentacao
                .FirstOrDefaultAsync(a => a.Pagina == "Home");

            return View(apresentacao);
        }

        // GET: Home/Destinos
        public async Task<IActionResult> Destinos()
        {
            var destinos = await _context.Destinos.ToListAsync();
            return View(destinos);
        }
    }
}
