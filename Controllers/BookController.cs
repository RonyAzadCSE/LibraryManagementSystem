// Controllers/BookController.cs
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            // Include BookCategory for display
            var applicationDbContext = _context.Books.Include(b => b.BookCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            // Populate dropdown for BookCategory
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategories, "Id", "Name");
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Author,ISBN,Publisher,BookCategoryId,CoverImageUrl,PublishedDate,TotalCopies")] Book book)
        {
            // In a real application, you might have specific validation here
            // (e.g., ISBN format, valid date). This is where data annotations would help.

            // Auto-calculate available copies
            book.AvailableCopies = book.TotalCopies;

            _context.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            // If there were validation errors, repopulate ViewData and return view
            // ViewData["BookCategoryId"] = new SelectList(_context.BookCategories, "Id", "Name", book.BookCategoryId);
            // return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategories, "Id", "Name", book.BookCategoryId);
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,ISBN,Publisher,BookCategoryId,CoverImageUrl,PublishedDate,TotalCopies,AvailableCopies")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            // In a real application, you might want to adjust AvailableCopies based on changes to TotalCopies
            // For now, we assume AvailableCopies is directly editable, or a more complex logic would be needed
            // to re-calculate it based on current borrowings.

            try
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            // If there were validation errors, repopulate ViewData and return view
            // ViewData["BookCategoryId"] = new SelectList(_context.BookCategories, "Id", "Name", book.BookCategoryId);
            // return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
