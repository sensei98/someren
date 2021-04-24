using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Timetable
    {
        public string Activity { get; set; }
        public string Supervisor { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }
        public string Status { get; set; }
    }
}
