using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain
{
    public class Campaign
    {
        public Campaign()
        {
            IsActive = true;
        }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime => this.StartTime.AddHours(this.Duration);
        public bool IsActive { get; set; }
    }
}
