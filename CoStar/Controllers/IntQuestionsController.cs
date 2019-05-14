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
    public class IntQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public IntQuestionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
			_userManager = userManager;
		}
		private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: IntQuestions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Questions.Include(i => i.User);
            return View(await applicationDbContext.ToListAsync());
        }

		// GET: IntQuestions/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intQuestion = await _context.Questions
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.IntQuestionId == id);
            if (intQuestion == null)
            {
                return NotFound();
            }

            return View(intQuestion);
        }

        // GET: IntQuestions/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: IntQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntQuestionId,IntQuestionName,IntQuestionDescription,UserId")] IntQuestion intQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", intQuestion.UserId);
            return View(intQuestion);
        }

        // GET: IntQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intQuestion = await _context.Questions.FindAsync(id);
            if (intQuestion == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", intQuestion.UserId);
            return View(intQuestion);
        }

        // POST: IntQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IntQuestionId,IntQuestionName,IntQuestionDescription,UserId")] IntQuestion intQuestion)
        {
            if (id != intQuestion.IntQuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntQuestionExists(intQuestion.IntQuestionId))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", intQuestion.UserId);
            return View(intQuestion);
        }

        // GET: IntQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intQuestion = await _context.Questions
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.IntQuestionId == id);
            if (intQuestion == null)
            {
                return NotFound();
            }

            return View(intQuestion);
        }

        // POST: IntQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intQuestion = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(intQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntQuestionExists(int id)
        {
            return _context.Questions.Any(e => e.IntQuestionId == id);
        }
    }
}
