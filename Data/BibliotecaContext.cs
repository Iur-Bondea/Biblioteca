using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext (DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<Biblioteca.Models.Book> Book { get; set; }

        public DbSet<Biblioteca.Models.Publisher> Publisher { get; set; }

        public DbSet<Biblioteca.Models.Category> Category { get; set; }

        public DbSet<Biblioteca.Models.Person> Person { get; set; }

        public DbSet<Biblioteca.Models.BorrowedBooks> BorrowedBooks { get; set; }

        public DbSet<Biblioteca.Models.Employee> Employee { get; set; }
    }
}
