using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Biblioteca.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Book Title")]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]
        public string Author { get; set; }

        public bool Available { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        [ForeignKey("PublisherID")]
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<BorrowedBooks> BorrowedBooks { get; set; }
    }
}

