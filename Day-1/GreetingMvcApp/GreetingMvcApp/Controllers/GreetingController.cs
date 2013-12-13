using GreetingMvcApp.Domain;
using GreetingMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreetingMvcApp.Controllers
{
 
    public class GreetingController : Controller
    {
        private ITimeService _timeService = default(ITimeService);
        
        public GreetingController()
        {
            this._timeService = new TimeService();
        }

        public GreetingController(ITimeService timeService)
        {
            this._timeService = timeService;
        }

        public ViewResult GreetInput()
        {
            return new ViewResult { ViewName = "GreetInput" };
        }

        //public ViewResult Greet(string firstName, string lastName) {
        //    var name = new GreetName { FirstName = firstName, LastName = lastName };
        //    var data = new ViewDataDictionary();
        //    data.Add(new KeyValuePair<string, object>("greetName", name));
            
        //    var viewName = "GreetDayOutput";
        //    if (this._timeService.GetTime().Hour > 17)
        //        viewName = "GreetNightOutput";

        //    return new ViewResult { ViewName = viewName, ViewData = data };
        //}

        public ViewResult Greet(string firstName, string lastName) { 
            var viewData = new ViewDataDictionary();
            var greetOutputModel = new GreetOutputModel{
                firstName = firstName,
                lastName = lastName
            };
            

            if (string.IsNullOrEmpty(firstName.Trim()))
            {
                greetOutputModel.errorMessages.Add("firstName", "First Name cannot be empty");
            }

            if (string.IsNullOrEmpty(lastName.Trim()))
            {
                greetOutputModel.errorMessages.Add("lastName", "Last Name cannot be empty");
            }
            if (greetOutputModel.errorMessages.Count == 0)
                greetOutputModel.greetMessage = string.Format("Hi {0} {1}", firstName, lastName);

            viewData.Add(new KeyValuePair<string, object>("GreetOutput", greetOutputModel));
            return new ViewResult{ViewName = "GreetOutput", ViewData = viewData};
        }
    }
}
