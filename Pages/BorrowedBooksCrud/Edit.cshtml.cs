using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Pages.BorrowedBooksCrud
{
    public class EditModel : PageModel
    {
        private readonly Biblioteca.Data.BibliotecaContext _context;

        public EditModel(Biblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BorrowedBooks BorrowedBooks { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BorrowedBooks = await _context.BorrowedBooks
                .Include(b => b.Book)
                .Include(b => b.Employee)
                .Include(b => b.Person).FirstOrDefaultAsync(m => m.ID == id);

            if (BorrowedBooks == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
            ViewData["PersonFirstName"] = new SelectList(_context.Person, "ID", "FirstName");
            ViewData["PersonLastName"] = new SelectList(_context.Person, "ID", "LastName");
            ViewData["EmployeeFirstName"] = new SelectList(_context.Employee, "ID", "FirstName");
            ViewData["EmployeeLastName"] = new SelectList(_context.Employee, "ID", "LastName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BorrowedBooks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowedBooksExists(BorrowedBooks.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowedBooksExists(int id)
        {
            return _context.BorrowedBooks.Any(e => e.ID == id);
        }
    }
}
