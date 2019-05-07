using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoStar.Controllers
{
    public class ImagesController : Controller
    {
		// GET: Images
		[HttpGet("principleimage")]
		public async Task<IActionResult> GetPrincipleImage(int profileId)
		{
			var principle = _context.Profiles.FindAsync(profileId);
			if (principle?.PrincipleImage == null) return NotFound();

			return File(principle.PrincipleImage, "image/jpeg");
		}

		// GET: Images/Details/5
		public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
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

        // GET: Images/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Images/Edit/5
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

        // GET: Images/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Images/Delete/5
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