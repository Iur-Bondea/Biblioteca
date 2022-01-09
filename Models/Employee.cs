using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Display(Name = "Employee First Name")]
        [RegularExpression(@"^[A-za-z]{1,40}$", ErrorMessage = "The field {0} is not a valid name")]
        public string FirstName { get; set; }

        [Display(Name = "Employee Last Name")]
        [RegularExpression(@"^[A-za-z]{1,40}$", ErrorMessage = "The field {0} is not a valid name")]
        public string LastName { get; set; }

        [Display(Name = "Contract Type")]
        [RegularExpression(@"^[A-za-z]{1,40}$", ErrorMessage = "The field {0} is not a valid contract type")]
        public string ContractType { get; set; }

        [Range(1400, int.MaxValue)]
        public int Salary { get; set; }

        public string IdentityNr { get; set; }


    }
}
