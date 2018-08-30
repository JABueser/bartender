using bartender.Models;
using bartender.Services;
using bartender.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinkData _drinkData;

        public DrinkController(IDrinkData drinkData)
        {
            _drinkData = drinkData;
        }


        public IActionResult Index()
        {
            var model = new DrinkIndexViewModel();
            model.Drinks = _drinkData.GetAll();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _drinkData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(DrinkEditModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var newDrink = new Drink();
        //        newDrink.Name = model.Name;
        //        newDrink.Description = model.Description;
        //        newDrink.Price = model.Price;
        //        newDrink.Image = model.Image;

        //        newDrink = _drinkData.Add(newDrink);

        //        return RedirectToAction(nameof(Details), new { id = newDrink.Id });
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var drinks = _drinkData.GetAll();
            var model = new DrinkIndexViewModel()
            {
                Drinks = drinks
            };

            return View(model.Drinks.FirstOrDefault(d => d.Id == Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Drink drink)
        {
            if (ModelState.IsValid)
            {
                _drinkData.Save(drink);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ViewResult Create() => View("Edit", new Drink());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            Drink deletedDrink = _drinkData.Delete(Id);
            if(deletedDrink != null)
            {
                TempData["message"] = $"{deletedDrink.Name} was deleted";
            }
            return Redirect("Index");
        }
    }
}
