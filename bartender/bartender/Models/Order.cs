using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public bool isDone { get; set; }
        public string DrinkName { get; set; }
        public DateTime TimeOrdered { get; set; }
        public int DrinkId { get; set; }
    }
}
