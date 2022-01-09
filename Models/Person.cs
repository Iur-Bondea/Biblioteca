using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Display(Name = "Person First Name")]
        [RegularExpression(@"^[A-za-z]{1,40}$", ErrorMessage = "The field {0} is not a valid name")]
        public string FirstName { get; set; }

        [Display(Name = "Person Last Name")]
        [RegularExpression(@"^[A-za-z]{1,40}$", ErrorMessage = "The field {0} is not a valid name")]
        public string LastName { get; set; }

        [Range(14, int.MaxValue)]
        public int Age { get; set; }
        public bool Student { get; set; }

        public ICollection<BorrowedBooks> BorrowedBooks { get; set; }

    }
}
