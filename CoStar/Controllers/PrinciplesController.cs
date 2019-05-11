using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoStar.Data;
using CoStar.Models;
using CoStar.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoStar.Controllers
{
    public class PrinciplesController : Controller
    {
		private readonly IHostingEnvironment _hostEnviro;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public PrinciplesController(IHostingEnvironment hostingEnvironment, ApplicationDbContext ctx, UserManager<ApplicationUser> userManager)
		{
			_hostEnviro = hostingEnvironment;
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

			var principle = await _context.Principles
			   .Include(p => p.User)
			   .FirstOrDefaultAsync(m => m.PrincipleId == id);

			if (principle == null)
			{
				return NotFound();
			}

			return View(principle);
		}

		// GET: Principles/Create
		public ActionResult Create()
        {
			return View(new PrincipleCreateViewModel());
		}

		// POST: Principles/Create
		[HttpPost]
		public async Task<IActionResult> Create(PrincipleCreateViewModel model)
		{
			try
			{
				ModelState.Remove("User");
				ModelState.Remove("UserId");
				if (ModelState.IsValid)
				{
					if (model.PrincipleFileToSave != null)
					{
						// These are required to save the file to the project's wwwroot/Images folder.
						var uniqueFileName = GetUniqueFileName(model.PrincipleFileToSave.FileName);
						var uploads = Path.Combine(_hostEnviro.WebRootPath, "Images");
						var filePath = Path.Combine(uploads, uniqueFileName);
						// Creating a formatted string to save to the Db.
						var imagepath = "~/Images/" + uniqueFileName;
						// Assign that variable to PrincipleImage.
						// Must drill down through the "model" parameter passed in here.
						model.Principle.PrincipleImage = imagepath;
						model.PrincipleFileToSave.CopyTo(new FileStream(filePath, FileMode.Create));
						// Identity.
						var User = await GetCurrentUserAsync();
						model.Principle.UserId = User.Id;
						// Based on the debugger, the file is added to the Images folder here. 

						// Data passed to Db.
						_context.Add(model.Principle);
						await _context.SaveChangesAsync();
					}
					// Redirect to the Details view of the newly created item.
					return RedirectToAction("Details", new { id = model.Principle.PrincipleId });
				}
			}
			catch (DbUpdateException /* exception */)
			{
				//Log the error (uncomment ex variable name and write a log.
				ModelState.AddModelError("", "Unable to save changes. " +
					"Try again, and if the problem persists " +
					"see your system administrator.");
			}
			return View(model);
		}
		private string GetUniqueFileName(string fileName)
		{
			fileName = Path.GetFileName(fileName);
			return Path.GetFileNameWithoutExtension(fileName)
					  + "_"
					  + Guid.NewGuid().ToString().Substring(0, 4)
					  + Path.GetExtension(fileName);
		}

		// GET: Principles/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var principle = await _context.Principles.FindAsync(id);
			if (principle == null)
			{
				return NotFound();
			}
			
			return View(principle);
		}

		// POST: Principles/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost, ActionName("Edit")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditPost(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var principleToUpdate = await _context.Principles.FirstOrDefaultAsync(p => p.PrincipleId == id);
			if (await TryUpdateModelAsync<Principle>(
				principleToUpdate,
				"",
				p => p.PrincipleImage, p => p.PrincipleName, p => p.PrincipleDescription))
			{
				try
				{
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateException /* exception */)
				{
					//Log the error (uncomment ex variable name and write a log.)
					ModelState.AddModelError("", "Unable to save changes. " +
						"Try again, and if the problem persists, " +
						"see your system administrator.");
				}
			}
			return View(principleToUpdate);
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