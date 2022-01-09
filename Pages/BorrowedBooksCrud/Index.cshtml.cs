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
    public class IndexModel : PageModel
    {
        private readonly Biblioteca.Data.BibliotecaContext _context;

        public IndexModel(Biblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        public IList<BorrowedBooks> BorrowedBooks { get;set; }

        public async Task OnGetAsync()
        {
            BorrowedBooks = await _context.BorrowedBooks
                .Include(b => b.Book)
                .Include(b => b.Employee)
                .Include(b => b.Person).ToListAsync();
        }
    }
}
