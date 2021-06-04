using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Image_WebApp.Data;
using Image_WebApp.Models;

namespace Image_WebApp.Controllers
{
    public class ImageUrlsController : Controller
    {
        private readonly ImageContext _context;

        public ImageUrlsController(ImageContext context)
        {
            _context = context;
        }

        // GET: ImageUrls
        public async Task<IActionResult> Index()
        {
            return View(await _context.ImageUrls.ToListAsync());
        }

        // GET: ImageUrls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageUrl = await _context.ImageUrls
                .FirstOrDefaultAsync(m => m.ID == id);
            if (imageUrl == null)
            {
                return NotFound();
            }

            return View(imageUrl);
        }

        // GET: ImageUrls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImageUrls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ImageName,Url")] ImageUrl imageUrl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imageUrl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageUrl);
        }

        // GET: ImageUrls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageUrl = await _context.ImageUrls.FindAsync(id);
            if (imageUrl == null)
            {
                return NotFound();
            }
            return View(imageUrl);
        }

        // POST: ImageUrls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ImageName,Url")] ImageUrl imageUrl)
        {
            if (id != imageUrl.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageUrl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageUrlExists(imageUrl.ID))
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
            return View(imageUrl);
        }

        // GET: ImageUrls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageUrl = await _context.ImageUrls
                .FirstOrDefaultAsync(m => m.ID == id);
            if (imageUrl == null)
            {
                return NotFound();
            }

            return View(imageUrl);
        }

        // POST: ImageUrls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageUrl = await _context.ImageUrls.FindAsync(id);
            _context.ImageUrls.Remove(imageUrl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageUrlExists(int id)
        {
            return _context.ImageUrls.Any(e => e.ID == id);
        }
    }
}
