using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Service
{
    public interface ITimeService
    {
        void IncreaseTime(int hour);        
        DateTime GetCurrentTime();
    }
}
