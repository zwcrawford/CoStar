using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoStar.Data;
using CoStar.Models;

namespace CoStar.Controllers
{
    public class WhiteboardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhiteboardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Whiteboards
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Whiteboards.Include(w => w.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Whiteboards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whiteboard = await _context.Whiteboards
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WhiteboardId == id);
            if (whiteboard == null)
            {
                return NotFound();
            }

            return View(whiteboard);
        }

        // GET: Whiteboards/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Whiteboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WhiteboardId,WhiteboardImage,WhiteboardName,WhiteboardDescription,UserId")] Whiteboard whiteboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whiteboard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", whiteboard.UserId);
            return View(whiteboard);
        }

        // GET: Whiteboards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whiteboard = await _context.Whiteboards.FindAsync(id);
            if (whiteboard == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", whiteboard.UserId);
            return View(whiteboard);
        }

        // POST: Whiteboards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WhiteboardId,WhiteboardImage,WhiteboardName,WhiteboardDescription,UserId")] Whiteboard whiteboard)
        {
            if (id != whiteboard.WhiteboardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whiteboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhiteboardExists(whiteboard.WhiteboardId))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", whiteboard.UserId);
            return View(whiteboard);
        }

        // GET: Whiteboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whiteboard = await _context.Whiteboards
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WhiteboardId == id);
            if (whiteboard == null)
            {
                return NotFound();
            }

            return View(whiteboard);
        }

        // POST: Whiteboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whiteboard = await _context.Whiteboards.FindAsync(id);
            _context.Whiteboards.Remove(whiteboard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhiteboardExists(int id)
        {
            return _context.Whiteboards.Any(e => e.WhiteboardId == id);
        }
    }
}
