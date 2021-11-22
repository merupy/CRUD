using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    [Index(nameof(PositionName), IsUnique = true)]

    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [StringLength(50)]
        public string PositionName { get; set; }
    }
}