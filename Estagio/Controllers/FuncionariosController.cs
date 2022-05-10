#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estagio.Models;
using estagio.Models;

namespace Estagio.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly Contexto _context;

        public FuncionariosController(Contexto context)
        {
            _context = context;
        }

        // GET: Funcinarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionarios.ToListAsync());
        }

        // GET: Funcinarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcinarios = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcinarios == null)
            {
                return NotFound();
            }

            return View(funcinarios);
        }

        // GET: Funcinarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcinarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Nascimento,Salario,Atividade")] Funcionarios funcinarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcinarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcinarios);
        }

        // GET: Funcinarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcinarios = await _context.Funcionarios.FindAsync(id);
            if (funcinarios == null)
            {
                return NotFound();
            }
            return View(funcinarios);
        }

        // POST: Funcinarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Nascimento,Salario,Atividade")] Funcionarios funcinarios)
        {
            if (id != funcinarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcinarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncinariosExists(funcinarios.Id))
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
            return View(funcinarios);
        }

        // GET: Funcinarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcinarios = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcinarios == null)
            {
                return NotFound();
            }

            return View(funcinarios);
        }

        // POST: Funcinarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcinarios = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(funcinarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncinariosExists(int id)
        {
            return _context.Funcionarios.Any(e => e.Id == id);
        }
    }
}
