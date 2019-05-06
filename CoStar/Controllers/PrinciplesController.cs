using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoStar.Data;
using CoStar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoStar.Controllers
{
    public class PrinciplesController : Controller
    {
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public PrinciplesController(ApplicationDbContext ctx,
						  UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
			_context = ctx;
		}

		private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

		// GET: Principles
		public async Task<IActionResult> Index()
        {
			return View(await _context.Principles.ToListAsync());
		}

		// GET: Principles/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var principles = await _context.Principles
			   .Include(p => p.UserId)
			   .FirstOrDefaultAsync(m => m.PrincipleId == id);

			if (principles == null)
			{
				return NotFound();
			}

			return View(principles);
		}

		// GET: Principles/Create
		public ActionResult Create()
        {
            return View();
        }

        // POST: Principles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Principles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Principles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Principles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Principles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}