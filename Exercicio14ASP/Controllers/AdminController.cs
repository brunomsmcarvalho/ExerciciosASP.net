using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Necessário para Session
using Microsoft.EntityFrameworkCore;
using Exercicio14ASP.Data;
using Exercicio14ASP.Models;

namespace Exercicio14ASP.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbMiniCMSContext _context;

        public AdminController(DbMiniCMSContext context)
        {
            _context = context;
        }

        // --- LOGIN ---

        // GET: Admin/Index (Página de Login)
        public IActionResult Index()
        {
            return View();
        }

        // POST: Admin/Index
        [HttpPost]
        public IActionResult Index(IFormCollection formCollection)
        {
            string user = formCollection["UserName"];
            string pass = formCollection["Password"];

            if (user == "admin" && pass == "admin")
            {
                HttpContext.Session.SetString("Login", "true");
                return RedirectToAction("Admin");
            }
            else
            {
                HttpContext.Session.SetString("Login", "false");
                ViewBag.Erro = "Login inválido!";
                return View();
            }
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        // --- ÁREA RESTRITA (ADMIN) ---

        // GET: Admin/Admin (Lista de Conteúdos)
        public async Task<IActionResult> Admin()
        {
            if (!IsAdmin()) return RedirectToAction("Index");

            return View(await _context.Conteudos.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!IsAdmin()) return RedirectToAction("Index");

            if (id == null) return NotFound();

            var conteudo = await _context.Conteudos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (conteudo == null) return NotFound();

            return View(conteudo);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            if (!IsAdmin()) return RedirectToAction("Index");
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pagina,Titulo,Texto,Autor,Data")] Conteudo conteudo)
        {
            if (!IsAdmin()) return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                _context.Add(conteudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Admin)); // Redireciona para a lista
            }
            return View(conteudo);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!IsAdmin()) return RedirectToAction("Index");

            if (id == null) return NotFound();

            var conteudo = await _context.Conteudos.FindAsync(id);
            if (conteudo == null) return NotFound();

            return View(conteudo);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pagina,Titulo,Texto,Autor,Data")] Conteudo conteudo)
        {
            if (!IsAdmin()) return RedirectToAction("Index");

            if (id != conteudo.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteudoExists(conteudo.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Admin));
            }
            return View(conteudo);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!IsAdmin()) return RedirectToAction("Index");

            if (id == null) return NotFound();

            var conteudo = await _context.Conteudos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (conteudo == null) return NotFound();

            return View(conteudo);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Index");

            var conteudo = await _context.Conteudos.FindAsync(id);
            if (conteudo != null)
            {
                _context.Conteudos.Remove(conteudo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Admin));
        }

        // --- MÉTODOS AUXILIARES ---

        // Função para evitar repetir a verificação de login em todo o lado
        private bool IsAdmin()
        {
            var login = HttpContext.Session.GetString("Login");
            return login != null && login == "true";
        }

        private bool ConteudoExists(int id)
        {
            return _context.Conteudos.Any(e => e.Id == id);
        }
    }
}