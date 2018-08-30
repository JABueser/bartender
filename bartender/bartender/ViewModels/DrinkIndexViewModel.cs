using bartender.Models;
using System.Collections.Generic;

namespace bartender.ViewModels
{
    public class DrinkIndexViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public string Name { get; set; }
        public int DrinkId { get; set; }
    }
}
