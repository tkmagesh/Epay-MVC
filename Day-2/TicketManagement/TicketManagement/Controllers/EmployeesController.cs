using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagement.Models;

namespace TicketManagement.Controllers
{
    public class EmployeesController : Controller
    {
        //
        // GET: /Employees/
        private static List<Employee> employees = new List<Employee>();
        public ActionResult Index()
        {
            return View(employees);
        }

        //
        // GET: /Employees/Details/5

        public ActionResult Details(int id)
        {
            return View(employees.FirstOrDefault(e => e.Id == id));
        }

        //
        // GET: /Employees/Create

        public ActionResult Create()
        {
            return View("CreateOrEdit", new Employee());
        }

        //
        // POST: /Employees/Create

        //[HttpPost]
        //public ActionResult Create(Employee employee)
        //{
        //    try
        //    {
        //        if (this.ModelState.IsValid)
        //        {
        //            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;

        //            employees.Add(employee);

        //            return RedirectToAction("Index");
        //        }
        //        else {
        //            return View(employee);
        //        }
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Employees/Edit/5

        public ActionResult Edit(int id)
        {
            return View("CreateOrEdit", employees.First(e => e.Id == id));
        }

        //
        // POST: /Employees/Edit/5

        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    if (employee.Id == 0)
                    {
                        employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
                        employees.Add(employee);
                    }
                    else
                    {
                        // TODO: Add update logic here
                        var emp = employees.First(e => e.Id == employee.Id);
                        emp.FirstName = employee.FirstName;
                        emp.LastName = employee.LastName;
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(employee);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Employees/Delete/5

        public ActionResult Delete(int id)
        {
            return View(employees.First(e => e.Id == id));
        }

        //
        // POST: /Employees/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                employees.Remove(employees.First(e => e.Id == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
