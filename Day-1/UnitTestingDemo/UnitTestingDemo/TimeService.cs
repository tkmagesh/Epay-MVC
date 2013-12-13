using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestingDemo
{
    public interface ITimeService {

        DateTime GetCurrentTime();
    }

    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
