using bartender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.Services
{
    public interface IOrderData
    {
        IEnumerable<Order> GetAll();
        Order Get(int id);
        Order Add(Order order);
        IEnumerable<Order> GetAllActive();
        void Save(Order order);
    }
}
