using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    [Index(nameof(PersonId), nameof(EmployeeCode), IsUnique = true)]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public int PersonId { get; set; } //fk

        [Required]
        public int PositionId { get; set; }  //fk

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string EmployeeCode { get; set; } = Guid.NewGuid().ToString();

        public bool IsDisabled { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; } 

        [ForeignKey("PositionId")]
        public Position Position { get; set; } 

    }
}