using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingDemo;
using System.Diagnostics;

namespace UnitTestingDemoTests
{
    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void Greeter_Reponds_With_Good_Day_When_Greeted_Before_17()
        {
            //Arrange
            var timeSvcForMorning = new FakeTimeServiceForMorning();
            var greeter = new Greeter(timeSvcForMorning);
            var name = "Magesh";
            var expectedResult = "Hi Magesh, Good Day";

            //Act
            var greetMsg = greeter.Greet(name);

            //Assert
            Assert.IsTrue(greetMsg.Equals(expectedResult));
        }

        [TestMethod]
        public void Greeter_Reponds_With_Good_Night_When_Greeted_After_17()
        {
            //Arrange
            var timeSvcForEvening = new FakeTimeServiceForEvening();
            var greeter = new Greeter(timeSvcForEvening);
            
            var name = "Magesh";
            var expectedResult = "Hi Magesh, Good Night";

            //Act
            var greetMsg = greeter.Greet(name);
            Debug.WriteLine(greetMsg);
            //Assert
            Assert.IsTrue(greetMsg.Equals(expectedResult));
        }
    }

    public class FakeTimeServiceForMorning : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2013, 12, 12, 9, 0, 0);
        }
    }

    public class FakeTimeServiceForEvening : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2013, 12, 12, 21, 0, 0);
        }
    }


}
