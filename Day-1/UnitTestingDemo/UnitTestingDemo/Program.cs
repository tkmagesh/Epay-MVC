using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name");
            var name = Console.ReadLine();
            var timeService = new TimeService();
            var greeter = new Greeter(timeService);
            Console.WriteLine(greeter.Greet(name));
            Console.ReadLine();
        }
    }

   
}
