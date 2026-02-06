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
    public class SegmentosController : Controller
    {
        private readonly DbTurismoContext _context;

        public SegmentosController(DbTurismoContext context)
        {
            _context = context;
        }

        // GET: Segmentos
        public async Task<IActionResult> Index()
        {
            var login = HttpContext.Session.GetString("Login");
            if (login == null)
            {
                return RedirectToAction("Index","Admin");
            }
            if (bool.Parse(login) == false)
            {
                return RedirectToAction("Index","Admin");
            }
            return View(await _context.Segmentos.ToListAsync());
        }

        // GET: Segmentos/Details/5
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

            var segmentos = await _context.Segmentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (segmentos == null)
            {
                return NotFound();
            }
            
            return View(segmentos);
        }

        // GET: Segmentos/Create
        public IActionResult Create()
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
            return View();
        }

        // POST: Segmentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SegmentoNome,Descricao")] Segmentos segmentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(segmentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(segmentos);
        }

        // GET: Segmentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segmentos = await _context.Segmentos.FindAsync(id);
            if (segmentos == null)
            {
                return NotFound();
            }
            var login = HttpContext.Session.GetString("Login");
            if (login == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (bool.Parse(login) == false)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View(segmentos);
        }

        // POST: Segmentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SegmentoNome,Descricao")] Segmentos segmentos)
        {
            if (id != segmentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(segmentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SegmentosExists(segmentos.Id))
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
            return View(segmentos);
        }

        // GET: Segmentos/Delete/5
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

            var segmentos = await _context.Segmentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (segmentos == null)
            {
                return NotFound();
            }
            
            return View(segmentos);
        }

        // POST: Segmentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var segmentos = await _context.Segmentos.FindAsync(id);
            if (segmentos != null)
            {
                _context.Segmentos.Remove(segmentos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SegmentosExists(int id)
        {
            return _context.Segmentos.Any(e => e.Id == id);
        }
    }
}
