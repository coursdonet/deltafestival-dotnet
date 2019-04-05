using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;

namespace BackOffice.Controllers
{
    public class CheckpointsController : Controller
    {
        private readonly EfContext _context;

        public CheckpointsController(EfContext context)
        {
            _context = context;
        }

        // GET: Checkpoints
        public async Task<IActionResult> Index()
        {
            return View(await _context.Checkpoint.ToListAsync());
        }

        // GET: Checkpoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkpoint = await _context.Checkpoint
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkpoint == null)
            {
                return NotFound();
            }

            return View(checkpoint);
        }

        // GET: Checkpoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Checkpoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,XAxis,YAxis,IsActive,IsObsolete")] Checkpoint checkpoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkpoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkpoint);
        }

        // GET: Checkpoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkpoint = await _context.Checkpoint.FindAsync(id);
            if (checkpoint == null)
            {
                return NotFound();
            }
            return View(checkpoint);
        }

        // POST: Checkpoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,XAxis,YAxis,IsActive,IsObsolete")] Checkpoint checkpoint)
        {
            if (id != checkpoint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkpoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckpointExists(checkpoint.Id))
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
            return View(checkpoint);
        }

        // GET: Checkpoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkpoint = await _context.Checkpoint
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkpoint == null)
            {
                return NotFound();
            }

            return View(checkpoint);
        }

        // POST: Checkpoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkpoint = await _context.Checkpoint.FindAsync(id);
            _context.Checkpoint.Remove(checkpoint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckpointExists(int id)
        {
            return _context.Checkpoint.Any(e => e.Id == id);
        }
    }
}
