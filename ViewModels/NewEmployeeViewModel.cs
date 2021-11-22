using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.ViewModels
{
    public class NewEmployeeViewModel
    {
        public Employee Employees { get; set; }

        public Person Persons { get; set; }

        public EmployeeJobHistory EmployeesJobHistory { get; set; }

        public IEnumerable<Position> Positions {get; set;} 
    }
}