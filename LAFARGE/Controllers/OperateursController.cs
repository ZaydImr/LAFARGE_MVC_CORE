using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAFARGE.Context;
using LAFARGE.Models;

namespace LAFARGE.Controllers
{
    public class OperateursController : Controller
    {
        private readonly lafargeContext _context;

        public OperateursController(lafargeContext context)
        {
            _context = context;
        }

        // GET: Operateurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Operateurs.ToListAsync());
        }

        // GET: Operateurs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operateur = await _context.Operateurs
                .FirstOrDefaultAsync(m => m.CinOperateur == id);
            if (operateur == null)
            {
                return NotFound();
            }

            return View(operateur);
        }

        // GET: Operateurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CinOperateur,PasswordOperateur,FullnameOperateur,NumeroOperateur,AdresseOperateur")] Operateur operateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operateur);
        }

        // GET: Operateurs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operateur = await _context.Operateurs.FindAsync(id);
            if (operateur == null)
            {
                return NotFound();
            }
            return View(operateur);
        }

        // POST: Operateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CinOperateur,PasswordOperateur,FullnameOperateur,NumeroOperateur,AdresseOperateur")] Operateur operateur)
        {
            if (id != operateur.CinOperateur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperateurExists(operateur.CinOperateur))
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
            return View(operateur);
        }

        // GET: Operateurs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operateur = await _context.Operateurs
                .FirstOrDefaultAsync(m => m.CinOperateur == id);
            if (operateur == null)
            {
                return NotFound();
            }

            return View(operateur);
        }

        // POST: Operateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var operateur = await _context.Operateurs.FindAsync(id);
            _context.Operateurs.Remove(operateur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperateurExists(string id)
        {
            return _context.Operateurs.Any(e => e.CinOperateur == id);
        }
    }
}
