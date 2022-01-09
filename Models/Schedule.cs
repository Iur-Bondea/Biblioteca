using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Schedule
    {

        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public int TimeTableID { get; set; }
        public TimeTable TimeTable { get; set; }

    }
}
