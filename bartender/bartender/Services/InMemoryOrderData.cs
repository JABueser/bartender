using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bartender.Models;

namespace bartender.Services
{
    public class InMemoryOrderData /* : IOrderData*/
    {
        public InMemoryOrderData()
        {
            _orders = new List<Order>
            {
                new Order
                {
                    OrderId=1,
                    isDone=false,
                    TimeOrdered = new DateTime(2002, 10, 17),
                    DrinkName="Wine"
                },
                new Order
                {
                    OrderId=2,
                    isDone=false,
                    TimeOrdered = new DateTime(2002, 10, 18),
                    DrinkName="Bud"
                },
                new Order
                {
                    OrderId=3,
                    isDone=true,
                    TimeOrdered = new DateTime(2002, 10, 19),
                    DrinkName="Beer"
                }
            };
        }

        public Order Add(Order order)
        {
            order.OrderId = _orders.Max(o => o.OrderId) + 1;
            _orders.Add(order);
            return order;
        }

        public Order Get(int id)
        {
            return _orders.FirstOrDefault(o => o.OrderId == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders.OrderBy(o => o.TimeOrdered);
        }

        public IEnumerable<Order> GetAllActive()
        {
            return _orders.Where(o => o.isDone == false);
        }

        List<Order> _orders;
    }
}
