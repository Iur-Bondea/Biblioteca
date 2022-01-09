using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Pages.BorrowedBooksCrud
{
    public class DetailsModel : PageModel
    {
        private readonly Biblioteca.Data.BibliotecaContext _context;

        public DetailsModel(Biblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
