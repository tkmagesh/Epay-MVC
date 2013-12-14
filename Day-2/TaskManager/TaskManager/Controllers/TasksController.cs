using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{

    public class TasksController : Controller
    {

        private static List<MyTask> _tasks = new List<MyTask>();
        //
        // GET: /Tasks/

        public ActionResult Index()
        {
            
            //var viewData = new ViewDataDictionary();
            //viewData.Add("tasks", _tasks);
            //return new ViewResult() { ViewName = "Index", ViewData = viewData };

            this.ViewData["tasks"] = _tasks; 
            return View("Index");
        }

        public ViewResult AddNew()
        {
            return View("AddNew");
        }

        public ActionResult Save(string newTask) {
            var currentTaskId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;

            _tasks.Add(new MyTask { 
                Id = currentTaskId,
                Name = newTask,
                IsCompleted = false
            });
            //var viewData = new ViewDataDictionary();
            //viewData.Add("tasks", _tasks);
            //return new ViewResult() { ViewName = "Index", ViewData = viewData };
            
            return RedirectToAction("Index");
        }

        public ActionResult ToggleCompletion(int Id) {
            var task = _tasks.FirstOrDefault(t => t.Id == Id);
            if (task != null)
                task.IsCompleted = !task.IsCompleted;
            //var viewData = new ViewDataDictionary();
            //viewData.Add("tasks", _tasks);
            //return new ViewResult() { ViewName = "Index", ViewData = viewData };
            return RedirectToAction("Index");
        }

    }
}
