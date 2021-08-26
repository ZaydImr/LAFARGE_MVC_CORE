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
    public class ChauffeursController : Controller
    {
        private readonly lafargeContext _context;

        public ChauffeursController(lafargeContext context)
        {
            _context = context;
        }

        // GET: Chauffeurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chauffeurs.ToListAsync());
        }

        // GET: Chauffeurs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeurs
                .FirstOrDefaultAsync(m => m.CinChauffeur == id);
            if (chauffeur == null)
            {
                return NotFound();
            }

            return View(chauffeur);
        }

        // GET: Chauffeurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chauffeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CinChauffeur,FullnameChauffeur,NumeroChauffeur,AdresseChauffeur")] Chauffeur chauffeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chauffeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chauffeur);
        }

        // GET: Chauffeurs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeurs.FindAsync(id);
            if (chauffeur == null)
            {
                return NotFound();
            }
            return View(chauffeur);
        }

        // POST: Chauffeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CinChauffeur,FullnameChauffeur,NumeroChauffeur,AdresseChauffeur")] Chauffeur chauffeur)
        {
            if (id != chauffeur.CinChauffeur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chauffeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChauffeurExists(chauffeur.CinChauffeur))
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
            return View(chauffeur);
        }

        // GET: Chauffeurs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeurs
                .FirstOrDefaultAsync(m => m.CinChauffeur == id);
            if (chauffeur == null)
            {
                return NotFound();
            }

            return View(chauffeur);
        }

        // POST: Chauffeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chauffeur = await _context.Chauffeurs.FindAsync(id);
            _context.Chauffeurs.Remove(chauffeur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChauffeurExists(string id)
        {
            return _context.Chauffeurs.Any(e => e.CinChauffeur == id);
        }
    }
}
