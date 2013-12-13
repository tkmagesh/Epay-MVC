using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreetingWebApp
{
    //public abstract class MyControllerBase : Controller
    //{
    //    protected virtual string GetHtml(string fileName)
    //    {
    //        return new StreamReader(Server.MapPath(@"\Htmls\" + fileName)).ReadToEnd();
    //    }
    //}
    public class GreetingController : Controller
    {
        public ViewResult GreetInput()
        {
            //return GetHtml("GreetInput.txt");
            return View("GreetInput");
        }
        public string Greet(string firstName, string lastName)
        {
            var responseTemplate = "GreetOutput.txt"; ;
            return string.Format(responseTemplate,firstName,lastName);
        }

        public ViewResult Index(){
            return View();
        }

        
    }
}