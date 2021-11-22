using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Models;
using CRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private MyCrudContext context;

        public EmployeesController(MyCrudContext context)
        {
            this.context = context;

        }

        public IActionResult Index()  //for listing employees + person table
        {
            var employees = context.Employees.Include(c => c.Person).ToList();
            return View(employees);
        }

        public IActionResult EmployeeForm()
        {
            var positions = context.Positions.ToList();
            var viewModel = new NewEmployeeViewModel
            {
                Positions = positions
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(NewEmployeeViewModel em)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewEmployeeViewModel
                { 
                    Positions = context.Positions.ToList()
                };
                return View("EmployeeForm",viewModel);
            }
            
            if (em.Employees.EmployeeId == 0)
            {
                Person p = new Person();
                p.FirstName = em.Persons.FirstName;
                p.MiddleName = em.Persons.MiddleName;
                p.LastName = em.Persons.LastName;
                p.Email = em.Persons.Email;
                p.Address = em.Persons.Address;
                context.Persons.Add(p);
                context.SaveChanges();

                Employee e = new Employee();
                e.PersonId = p.PersonId;
                e.PositionId = em.Employees.PositionId;
                e.StartDate = em.Employees.StartDate;
                e.EndDate = em.Employees.EndDate;
                context.Employees.Add(e);
                context.SaveChanges();

                EmployeeJobHistory eh = new EmployeeJobHistory();
                eh.EmployeeId = e.EmployeeId;
                eh.PositionId = em.Employees.PositionId;
                eh.StartDate = em.Employees.StartDate;
                eh.EndDate = em.Employees.EndDate;
                context.EmployeeJobHistories.Add(eh);
                context.SaveChanges();
            }
            else
            {
                var employeeDb = context.Employees.Include(c => c.Person).Single(e=>e.EmployeeId == em.Employees.EmployeeId );

                employeeDb.Person.FirstName = em.Employees.Person.FirstName;
                employeeDb.Person.MiddleName = em.Employees.Person.MiddleName;
                employeeDb.Person.LastName = em.Employees.Person.LastName;
                employeeDb.Person.Email = em.Employees.Person.Email;
                employeeDb.PositionId =em.Employees.PositionId;
                employeeDb.Person.Address = em.Employees.Person.Address;
                employeeDb.StartDate = em.Employees.StartDate;
                employeeDb.EndDate = em.Employees.EndDate;
                employeeDb.Salary = em.Employees.Salary;
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Employees");
        }


        public IActionResult Update(int id) //int Id)
        {
          var employee = context.Employees.Include(c => c.Person).SingleOrDefault(e=>e.EmployeeId==id);

          var viewmodel = new NewEmployeeViewModel
          {
              Employees = employee,
              Positions = context.Positions.ToList()
          };
          return View("Update", viewmodel);

        }

        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Include(c => c.Person).SingleOrDefault(e=>e.EmployeeId==id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }
    }
}