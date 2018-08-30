using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bartender.Data;
using bartender.Models;

namespace bartender.Services
{
    public class SqlOrderData : IOrderData
    {
        private BartenderDbContext _context;

        public SqlOrderData(BartenderDbContext context)
        {
            _context = context;
        }

        public Order Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void Save(Order order)
        {
            Order dbEntry = _context.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if(dbEntry != null)
            {
                dbEntry.DrinkId = order.DrinkId;
                dbEntry.DrinkName = order.DrinkName;
                dbEntry.isDone = order.isDone;
            }
            _context.SaveChanges();
        }

        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.OrderBy(o => o.TimeOrdered);
        }
        public IEnumerable<Order> GetAllActive()
        {
            return _context.Orders.Where(o => o.isDone == false);
        }

       
    }
}
