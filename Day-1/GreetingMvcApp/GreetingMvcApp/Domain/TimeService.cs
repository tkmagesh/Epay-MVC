using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreetingMvcApp.Domain
{
    public class TimeService : ITimeService
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}