// Controllers/BookCategoryController.cs
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class BookCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookCategory
        public async Task<IActionResult> Index()
        {
            var data = await _context.BookCategories.ToListAsync();
            return View(data);
        }

        // GET: BookCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // GET: BookCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookCategory/Create
        [HttpPost]
        public async Task<IActionResult> Create(BookCategory bookCategory)
        {
            if (bookCategory.CategoryName != null)
            {
                _context.Add(bookCategory);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
        
                return Json(new { success = false});
        }

        // GET: BookCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories.FindAsync(id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            return View(bookCategory);
        }

        // POST: BookCategory/Edit/5
        [HttpPost]
        public IActionResult Edit(BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _context.BookCategories.Update(bookCategory);
                _context.SaveChanges();
                return Json(new { success = true });
            }

            return BadRequest(ModelState);
        }


        // GET: BookCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            // Check if there are any books associated with this category
            var hasBooks = await _context.Books.AnyAsync(b => b.BookCategoryId == id);
            ViewBag.HasBooks = hasBooks; // Pass this to the view

            return View(bookCategory);
        }

        // POST: BookCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCategory = await _context.BookCategories.FindAsync(id);
            if (bookCategory != null)
            {
                // Prevent deletion if books are associated
                if (await _context.Books.AnyAsync(b => b.BookCategoryId == id))
                {
                    TempData["ErrorMessage"] = "Cannot delete this category as books are associated with it. Please reassign or delete the associated books first.";
                    return RedirectToAction(nameof(Delete), new { id = id });
                }

                _context.BookCategories.Remove(bookCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCategoryExists(int id)
        {
            return _context.BookCategories.Any(e => e.Id == id);
        }
    }
}
