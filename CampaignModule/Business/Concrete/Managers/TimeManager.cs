using Business.Abstract.Service;
using DataAccess;
using System;

namespace Business.Concrete.Managers
{
    public class TimeManager : ITimeService
    {
        private static DateTime _timeSimulator = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                0, 0, 0);
        public DateTime GetCurrentTime()
        {
            return _timeSimulator;
        }

        public void IncreaseTime(int hour)
        {
            _timeSimulator = _timeSimulator.AddHours(hour);
        }        
    }
}
