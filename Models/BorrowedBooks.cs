using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class BorrowedBooks
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        [DataType(DataType.Date)]
        public DateTime BorrowedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public bool BookReturned { get; set; }

        [Required, StringLength(250, MinimumLength = 3)]
        [Display(Name = "Reviews")]
        public string Reviews { get; set; }

    }
}
