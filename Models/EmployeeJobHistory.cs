using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    [Index(nameof(EmployeeId), nameof(PositionId), IsUnique = true)]

    public class EmployeeJobHistory
    {
        [Key]
        public int EmployeeJobHistoryId { get; set; }

        public int EmployeeId { get; set; } //fk

        public int PositionId { get; set; } //fk

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } 

        [ForeignKey("PositionId")]
        public Position Position { get; set; } 


    }
}