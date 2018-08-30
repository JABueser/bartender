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
    public class HomeController : Controller
    {
        private IDrinkData _drinkData;

        public HomeController(IDrinkData drinkData)
        {
            _drinkData = drinkData;
        }


        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Drinks = _drinkData.GetAll();
            model.CurrentMessage = "Test";

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _drinkData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DrinkEditModel model)
        {
            if (ModelState.IsValid)
            {

                var newDrink = new Drink();
                newDrink.Name = model.Name;
                newDrink.Alchohol = model.Alchohol;

                newDrink = _drinkData.Add(newDrink);

                return RedirectToAction(nameof(Details), new { id = newDrink.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
