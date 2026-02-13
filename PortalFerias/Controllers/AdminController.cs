using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalFerias.Data;
using PortalFerias.Models;

namespace PortalFerias.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbPortalFeriasContext _context;

        public AdminController(DbPortalFeriasContext context)
        {
            _context = context;
        }

        // GET: Admin/Index (Login Page)
        public IActionResult Index()
        {
            return View();
        }

        // POST: Admin/Index (Login)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                HttpContext.Session.SetString("IsAuthenticated", "true");
                return RedirectToAction(nameof(Lista));
            }

            ViewBag.Error = "Credenciais inválidas!";
            return View();
        }

        // GET: Admin/Lista
        public async Task<IActionResult> Lista()
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction(nameof(Index));
            }

            var destinos = await _context.Destinos.ToListAsync();
            return View(destinos);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Pais,Preco")] Destino_BC destino)
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                _context.Add(destino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }
            return View(destino);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction(nameof(Index));
            }

            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.Destinos.FindAsync(id);
            if (destino == null)
            {
                return NotFound();
            }
            return View(destino);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Pais,Preco")] Destino_BC destino)
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction(nameof(Index));
            }

            if (id != destino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoExists(destino.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Lista));
            }
            return View(destino);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction(nameof(Index));
            }

            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.Destinos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction(nameof(Index));
            }

            var destino = await _context.Destinos.FindAsync(id);
            if (destino != null)
            {
                _context.Destinos.Remove(destino);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction(nameof(Index));
            }

            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.Destinos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        // GET: Admin/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoExists(int id)
        {
            return _context.Destinos.Any(e => e.Id == id);
        }

    }
}
