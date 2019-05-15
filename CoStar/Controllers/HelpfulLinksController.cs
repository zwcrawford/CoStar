using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoStar.Data;
using CoStar.Models;
using Microsoft.AspNetCore.Identity;

namespace CoStar.Controllers
{
    public class HelpfulLinksController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public HelpfulLinksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
			_userManager = userManager;
		}
		private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

		// GET: HelpfulLinks
		public async Task<IActionResult> Index()
        {
			var currentUser = await GetCurrentUserAsync();
			return View(await _context.Links.Where(l => l.UserId == currentUser.Id || l.UserId == null).ToListAsync());
		}

        // GET: HelpfulLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpfulLink = await _context.Links
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.HelpfulLinkId == id);
            if (helpfulLink == null)
            {
                return NotFound();
            }

            return View(helpfulLink);
        }

        // GET: HelpfulLinks/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: HelpfulLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HelpfulLinkId,LinkUrl,LinkDescription,UserId")] HelpfulLink helpfulLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(helpfulLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", helpfulLink.UserId);
            return View(helpfulLink);
        }

        // GET: HelpfulLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpfulLink = await _context.Links.FindAsync(id);
            if (helpfulLink == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", helpfulLink.UserId);
            return View(helpfulLink);
        }

        // POST: HelpfulLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HelpfulLinkId,LinkUrl,LinkDescription,UserId")] HelpfulLink helpfulLink)
        {
            if (id != helpfulLink.HelpfulLinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helpfulLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelpfulLinkExists(helpfulLink.HelpfulLinkId))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", helpfulLink.UserId);
            return View(helpfulLink);
        }

        // GET: HelpfulLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpfulLink = await _context.Links
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.HelpfulLinkId == id);
            if (helpfulLink == null)
            {
                return NotFound();
            }

            return View(helpfulLink);
        }

        // POST: HelpfulLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helpfulLink = await _context.Links.FindAsync(id);
            _context.Links.Remove(helpfulLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelpfulLinkExists(int id)
        {
            return _context.Links.Any(e => e.HelpfulLinkId == id);
        }
    }
}
