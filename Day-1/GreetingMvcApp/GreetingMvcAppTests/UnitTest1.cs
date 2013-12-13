using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreetingMvcApp.Domain;
using GreetingMvcApp.Controllers;
using System.Web.Mvc;

namespace GreetingMvcAppTests
{
    public class DayTimeService : ITimeService
    {
        public DateTime GetTime()
        {
            return new DateTime(2013, 12, 12, 9,0,0);
        }
    }

    public class NightTimeService : ITimeService
    {
        public DateTime GetTime()
        {
            return new DateTime(2013, 12, 12, 21, 0, 0);
        }
    }


    [TestClass]
    public class GreetingControllerTests
    {
        [TestMethod]
        public void DayViewIsReturnedForMorning()
        {
            //Arrange
            var firstName = "Magesh";
            var lastName = "K";
            var timeService = new DayTimeService();
            var controller = new GreetingController(timeService);

            //Act
            var result = (ViewResult) controller.Greet(firstName, lastName);

            //Assert
            Assert.AreEqual(result.ViewName, "GreetDayOutput");
        }

        [TestMethod]
        public void NightViewIsReturnedForEvening()
        {
            //Arrange
            var firstName = "Magesh";
            var lastName = "K";
            var timeService = new NightTimeService();
            var controller = new GreetingController(timeService);

            //Act
            var result = (ViewResult)controller.Greet(firstName, lastName);

            //Assert
            Assert.AreEqual(result.ViewName, "GreetNightOutput");
        }
    }
}
