using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [StringLength (50)]
        public string FirstName { get; set; }

        [StringLength (50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength (50)]
        public string LastName { get; set; }

        [Required]
        [StringLength (100)]
        public string Address { get; set; }

        [Required]
        [StringLength (50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}