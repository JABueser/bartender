using bartender.Models;
using System.Collections.Generic;

namespace bartender.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public string CurrentMessage { get; set; }
    }
}
