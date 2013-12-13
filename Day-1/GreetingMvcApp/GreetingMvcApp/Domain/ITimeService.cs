using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreetingMvcApp.Domain
{
    public interface ITimeService
    {
        DateTime GetTime();
    }
}
