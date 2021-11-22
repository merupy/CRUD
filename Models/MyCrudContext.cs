using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class MyCrudContext : DbContext
    {
        public MyCrudContext(DbContextOptions<MyCrudContext>options): base(options) 
        {

        }
        public DbSet<Person> Persons {get; set;}

        public DbSet<Employee> Employees {get; set;}
        public DbSet<EmployeeJobHistory> EmployeeJobHistories {get; set;}
        public DbSet<Position> Positions {get; set;}
    }
}