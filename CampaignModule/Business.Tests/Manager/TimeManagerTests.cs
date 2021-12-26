using Business.Concrete.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.Manager
{
    [TestClass]
    public class TimeManagerTests
    {
        [TestMethod]
        public void GetCurrentTimeTest()
        {
            var timeManager = new TimeManager();            
            var expected = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                0, 0, 0);

            var result = timeManager.GetCurrentTime();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IncreaseTimeTest()
        {
            var timeManager = new TimeManager();            
            timeManager.IncreaseTime(2);
            var result = timeManager.GetCurrentTime();
            var expectedHour = 2;
            Assert.AreEqual(expectedHour, result.Hour);
        }
    }
}
