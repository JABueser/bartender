using bartender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.ViewModels
{
    public class OrderListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public int orderId { get; set; }
    }
}
