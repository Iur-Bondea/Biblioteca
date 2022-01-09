using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Pages.BorrowedBooksCrud
{
    public class CreateModel : PageModel
    {
        private readonly Biblioteca.Data.BibliotecaContext _context;

        public CreateModel(Biblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
            ViewData["PersonFirstName"] = new SelectList(_context.Person, "ID", "FirstName");
            ViewData["PersonLastName"] = new SelectList(_context.Person, "ID", "LastName");
            ViewData["EmployeeFirstName"] = new SelectList(_context.Employee, "ID", "FirstName");
            ViewData["EmployeeLastName"] = new SelectList(_context.Employee, "ID", "LastName");
            return Page();
        }

        [BindProperty]
        public BorrowedBooks BorrowedBooks { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BorrowedBooks.Add(BorrowedBooks);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
