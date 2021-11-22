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
    public class EmployeesJobHistoryController : Controller
    {
        private MyCrudContext context;

        public EmployeesJobHistoryController(MyCrudContext context)
        {
            this.context = context;

        }

        public IActionResult Index(int id)  //for listing hiatory + position
        {
            var employeehistory = context.EmployeeJobHistories.Where(c=>c.EmployeeId == id);    //(c => c.Employee).ToList().SingleOrDefault(e=>e.EmployeeId==id);

            //var employeesjob = context.EmployeeJobHistories.Include(c=>c.Employee).ToList();
            return View(employeehistory);
        }

        [HttpPost]
        public IActionResult Save(NewEmployeeViewModel em)  //which start date and end date ? confusion...
        {
            var employeeDb = context.Employees.Single(e=>e.EmployeeId == em.Employees.EmployeeId);

            employeeDb.StartDate = em.Employees.StartDate;
            employeeDb.EndDate = em.Employees.EndDate;
            context.SaveChanges();
            return RedirectToAction("Index", "EmployeesJobHistory");

        }

        public IActionResult Update(int id)
        {
          var employee = context.Employees.SingleOrDefault(e=>e.EmployeeId==id);

          var viewmodel = new NewEmployeeViewModel
          {
              Employees = employee
          };
          return View("Update", viewmodel);

        }
    }
}