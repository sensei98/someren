using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drinks
    {
        public String NameOfDrink { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
        
        public int Stock { get; set; }
       
        public bool isAlcholic { get; set; }
        public int Amount { get; set; }
    }
}
