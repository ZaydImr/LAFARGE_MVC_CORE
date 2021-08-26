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
    public class CommandesController : Controller
    {
        private readonly lafargeContext _context;

        public CommandesController(lafargeContext context)
        {
            _context = context;
        }

        // GET: Commandes
        public async Task<IActionResult> Index()
        {
            var lafargeContext = _context.Commandes.Include(c => c.CinChauffeurNavigation).Include(c => c.CinOperateurNavigation).Include(c => c.CodeClientNavigation).Include(c => c.IdQualityNavigation);
            return View(await lafargeContext.ToListAsync());
        }

        // GET: Commandes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes
                .Include(c => c.CinChauffeurNavigation)
                .Include(c => c.CinOperateurNavigation)
                .Include(c => c.CodeClientNavigation)
                .Include(c => c.IdQualityNavigation)
                .FirstOrDefaultAsync(m => m.BonCommande == id);
            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // GET: Commandes/Create
        public IActionResult Create()
        {
            ViewData["CinChauffeur"] = new SelectList(_context.Chauffeurs, "CinChauffeur", "CinChauffeur");
            ViewData["CinOperateur"] = new SelectList(_context.Operateurs, "CinOperateur", "CinOperateur");
            ViewData["CodeClient"] = new SelectList(_context.Clients, "CodeClient", "NomClient");
            ViewData["IdQuality"] = new SelectList(_context.Qualities, "IdQuality", "NameQuality");
            return View();
        }

        // POST: Commandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BonCommande,CinOperateur,CodeClient,IdQuality,Quantity,Unite,Matricule,Tare,TonnageReel,CinChauffeur,HeureChargement,HeureLivraison,Verification")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinChauffeur"] = new SelectList(_context.Chauffeurs, "CinChauffeur", "CinChauffeur", commande.CinChauffeur);
            ViewData["CinOperateur"] = new SelectList(_context.Operateurs, "CinOperateur", "CinOperateur", commande.CinOperateur);
            ViewData["CodeClient"] = new SelectList(_context.Clients, "CodeClient", "NomClient", commande.CodeClient);
            ViewData["IdQuality"] = new SelectList(_context.Qualities, "IdQuality", "NameQuality", commande.IdQuality);
            return View(commande);
        }

        // GET: Commandes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }
            ViewData["CinChauffeur"] = new SelectList(_context.Chauffeurs, "CinChauffeur", "CinChauffeur", commande.CinChauffeur);
            ViewData["CinOperateur"] = new SelectList(_context.Operateurs, "CinOperateur", "CinOperateur", commande.CinOperateur);
            ViewData["CodeClient"] = new SelectList(_context.Clients, "CodeClient", "NomClient", commande.CodeClient);
            ViewData["IdQuality"] = new SelectList(_context.Qualities, "IdQuality", "NameQuality", commande.IdQuality);
            return View(commande);
        }

        // POST: Commandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BonCommande,CinOperateur,CodeClient,IdQuality,Quantity,Unite,Matricule,Tare,TonnageReel,CinChauffeur,HeureChargement,HeureLivraison,Verification")] Commande commande)
        {
            if (id != commande.BonCommande)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commande);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandeExists(commande.BonCommande))
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
            ViewData["CinChauffeur"] = new SelectList(_context.Chauffeurs, "CinChauffeur", "CinChauffeur", commande.CinChauffeur);
            ViewData["CinOperateur"] = new SelectList(_context.Operateurs, "CinOperateur", "CinOperateur", commande.CinOperateur);
            ViewData["CodeClient"] = new SelectList(_context.Clients, "CodeClient", "NomClient", commande.CodeClient);
            ViewData["IdQuality"] = new SelectList(_context.Qualities, "IdQuality", "NameQuality", commande.IdQuality);
            return View(commande);
        }

        // GET: Commandes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes
                .Include(c => c.CinChauffeurNavigation)
                .Include(c => c.CinOperateurNavigation)
                .Include(c => c.CodeClientNavigation)
                .Include(c => c.IdQualityNavigation)
                .FirstOrDefaultAsync(m => m.BonCommande == id);
            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // POST: Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commande = await _context.Commandes.FindAsync(id);
            _context.Commandes.Remove(commande);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandeExists(int id)
        {
            return _context.Commandes.Any(e => e.BonCommande == id);
        }
    }
}
