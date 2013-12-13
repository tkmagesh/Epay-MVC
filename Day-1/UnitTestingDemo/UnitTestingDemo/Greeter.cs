using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestingDemo
{
    public class Greeter
    {
        public Greeter(ITimeService timeService)
        {
            this._timeService = timeService;
        }
        public string Greet(string name)
        {
            
            if (_timeService.GetCurrentTime().Hour < 17)
                return string.Format("Hi {0}, Good Day", name);
            return string.Format("Hi {0}, Good Night", name);
        }

        private ITimeService _timeService;
    }
}
