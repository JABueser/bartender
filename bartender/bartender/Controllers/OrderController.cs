using bartender.Models;
using bartender.Services;
using bartender.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.Controllers
{
    public class OrderController : Controller
    {
        private IOrderData _orderData;
        private IDrinkData _drinkData;

        public OrderController(IOrderData orderData, IDrinkData drinkData)
        {
            _orderData = orderData;
            _drinkData = drinkData;
        }

        public IActionResult Index()
        {
            var model = new OrderListViewModel();
            model.Orders = _orderData.GetAllActive();

            return View(model);
        }

        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(DrinkIndexViewModel model)
        {
            var newOrder = new Order();
            newOrder.isDone = false;
            newOrder.DrinkName = model.Name;
            newOrder.DrinkId = model.DrinkId;
            newOrder.TimeOrdered = DateTime.Now;

            newOrder = _orderData.Add(newOrder);

            return RedirectToAction("Index", "Drink");

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Finish(int Id)
        {
            var order = _orderData.Get(Id);
            if (ModelState.IsValid)
            {
                order.isDone = true;
                _orderData.Save(order);
            }
            return RedirectToAction("Index");

        }

    }
}
