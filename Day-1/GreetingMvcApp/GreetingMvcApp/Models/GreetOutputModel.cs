using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreetingMvcApp.Models
{
    public class GreetOutputModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string greetMessage { get; set; }
        public Dictionary<string, string> errorMessages { get; set; }
        public GreetOutputModel()
        {
            errorMessages = new Dictionary<string, string>();
        }
    }
}