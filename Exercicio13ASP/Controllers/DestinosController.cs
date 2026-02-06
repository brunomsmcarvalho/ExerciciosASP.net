using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exercicio13ASP.Data;
using Exercicio13ASP.Models;

namespace Exercicio13ASP.Controllers
{
    public class DestinosController : Controller
    {
        private readonly DbTurismoContext _context;

        public DestinosController(DbTurismoContext context)
        {
            _context = context;
        }

        // GET: Destinos
        public async Task<IActionResult> Index()
        {
            var login = HttpContext.Session.GetString("Login");
            if (login == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (bool.Parse(login) == false)
            {
                return RedirectToAction("Index", "Admin");
            }
            var dbTurismoContext = _context.Destinos.Include(d => d.Segmentos);
            return View(await dbTurismoContext.ToListAsync());
        }

        // GET: Destinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var login = HttpContext.Session.GetString("Login");
            if (login == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (bool.Parse(login) == false)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (id == null)
            {
                return NotFound();
            }

            var destinos = await _context.Destinos
                .Include(d => d.Segmentos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinos == null)
            {
                return NotFound();
            }

            return View(destinos);
        }

        // GET: Destinos/Create
        public IActionResult Create()
        {
            ViewData["Segmento"] = new SelectList(_context.Segmentos, "Id", "SegmentoNome");
            var login = HttpContext.Session.GetString("Login");
            if (login == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (bool.Parse(login) == false)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        // POST: Destinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Regiao,SegmentosId")] Destinos destinos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SegmentosId"] = new SelectList(_context.Segmentos, "Id", "Id", destinos.SegmentosId);
            var login = HttpContext.Session.GetString("Login");
           
            return View(destinos);
        }

        // GET: Destinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinos = await _context.Destinos.FindAsync(id);
            if (destinos == null)
            {
                return NotFound();
            }
            ViewData["SegmentosId"] = new SelectList(_context.Segmentos, "Id", "Id", destinos.SegmentosId);
            var login = HttpContext.Session.GetString("Login");
            if (login == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (bool.Parse(login) == false)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View(destinos);
        }

        // POST: Destinos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Regiao,SegmentosId")] Destinos destinos)
        {
            if (id != destinos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinosExists(destinos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SegmentosId"] = new SelectList(_context.Segmentos, "Id", "Id", destinos.SegmentosId);
            return View(destinos);
        }

        // GET: Destinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var login = HttpContext.Session.GetString("Login");
            if (login == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (bool.Parse(login) == false)
            {
                return RedirectToAction("Index", "Admin");
            }

            if (id == null)
            {
                return NotFound();
            }

            var destinos = await _context.Destinos
                .Include(d => d.Segmentos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinos == null)
            {
                return NotFound();
            }
            
            return View(destinos);
        }

        // POST: Destinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinos = await _context.Destinos.FindAsync(id);
            if (destinos != null)
            {
                _context.Destinos.Remove(destinos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinosExists(int id)
        {
            return _context.Destinos.Any(e => e.Id == id);
        }
    }
}
