﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Pages.Persons
{
    public class DetailsModel : PageModel
    {
        private readonly Biblioteca.Data.BibliotecaContext _context;

        public DetailsModel(Biblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.ID == id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
