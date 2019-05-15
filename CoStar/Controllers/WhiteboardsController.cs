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
	public class WhiteboardsController : Controller
	{
		private readonly IHostingEnvironment _hostEnviro;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;


		public WhiteboardsController(IHostingEnvironment hostingEnvironment, ApplicationDbContext ctx, UserManager<ApplicationUser> userManager)
		{
			_hostEnviro = hostingEnvironment;
			_userManager = userManager;
			_context = ctx;
		}

		private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

		// GET: Whiteboards
		public async Task<IActionResult> Index()
		{
			var currentUser = await GetCurrentUserAsync();
			return View(await _context.Whiteboards.Where(w => w.UserId == currentUser.Id || w.UserId == null).ToListAsync());
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
		public ActionResult Create()
		{
			return View(new WhiteboardCreateViewModel());
		}

		// POST: Whiteboards/Create
		[HttpPost]
		public async Task<IActionResult> Create(WhiteboardCreateViewModel model)
		{
			try
			{
				//ModelState.Remove("User");
				//ModelState.Remove("UserId");
				if (ModelState.IsValid)
				{
					if (model.WhiteboardFileToSave != null)
					{
						// These are required to save the file to the project's wwwroot/Images folder.
						var uniqueFileName = GetUniqueFileName(model.WhiteboardFileToSave.FileName);
						var uploads = Path.Combine(_hostEnviro.WebRootPath, "Images");
						var filePath = Path.Combine(uploads, uniqueFileName);
						// Creating a formatted string to save to the Db.
						var imagepath = "~/Images/" + uniqueFileName;
						// Assign that variable to WhiteboardImage.
						// Must drill down through the "model" parameter passed in here.
						model.Whiteboard.WhiteboardImage = imagepath;
						model.WhiteboardFileToSave.CopyTo(new FileStream(filePath, FileMode.Create));
						// Identity.
						var User = await GetCurrentUserAsync();
						model.Whiteboard.UserId = User.Id;
						// Based on the debugger, the file is added to the Images folder here. 

						// Data passed to Db.
						_context.Add(model.Whiteboard);
						await _context.SaveChangesAsync();
					}
					// Redirect to the Details view of the newly created item.
					return RedirectToAction("Details", new { id = model.Whiteboard.WhiteboardId });
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
			// Must initialize 
			var viewModel = new WhiteboardEditViewModel()
			{
				Whiteboard = whiteboard
			};
			return View(viewModel);
		}

		// POST: Whiteboards/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, WhiteboardEditViewModel viewModel)
		{
			var whiteboard = viewModel.Whiteboard;

			if (id != whiteboard.WhiteboardId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					//ModelState.Remove("User");
					//ModelState.Remove("UserId");
					if (ModelState.IsValid)
					{
						if (viewModel.WhiteboardFileToSave != null)
						{
							// These are required to save the file to the project's wwwroot/Images folder.
							var uniqueFileName = GetUniqueFileName(viewModel.WhiteboardFileToSave.FileName);
							var uploads = Path.Combine(_hostEnviro.WebRootPath, "Images");
							var filePath = Path.Combine(uploads, uniqueFileName);
							// Creating a formatted string to save to the Db.
							var imagepath = "~/Images/" + uniqueFileName;
							// Assign that variable to WhiteboardImage.
							// Must drill down through the "model" parameter passed in here.
							viewModel.Whiteboard.WhiteboardImage = imagepath;
							viewModel.WhiteboardFileToSave.CopyTo(new FileStream(filePath, FileMode.Create));
							// Identity.
							var User = await GetCurrentUserAsync();
							viewModel.Whiteboard.UserId = User.Id;
							// Based on the debugger, the file is added to the Images folder here. 

							// Data passed to Db.
							_context.Update(viewModel.Whiteboard);
							await _context.SaveChangesAsync();
						}
						// Redirect to the Details view of the newly created item.
						return RedirectToAction("Details", new { id = viewModel.Whiteboard.WhiteboardId });
					}
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
			return View(viewModel);
		}
		private bool WhiteboardExists(int id)
		{
			return _context.Whiteboards.Any(e => e.WhiteboardId == id);
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
				.FirstOrDefaultAsync(w => w.WhiteboardId == id);
			if (whiteboard == null)
			{
				return NotFound();
			}

			return View(whiteboard);
		}

		// POST: Whiteboards/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id, WhiteboardDeleteViewModel viewModel)
		{
			var whiteboard = await _context.Whiteboards.FindAsync(id);
			_context.Whiteboards.Remove(whiteboard);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}