using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Student
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }
        public int StudentNumber { get; set; } // StudentNumber, e.g. 474791
        public int Year { get; set; }
        public string FullName { get { return FirstName + " " + LastName; }  }

    }
}
