using bartender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.Services
{
    public class InMemoryDrinkData : IDrinkData
    {
        public InMemoryDrinkData()
        {
            _drinks = new List<Drink>
            {
                new Drink
                {
                    Id=1,
                    Name="Beer"
                },
                new Drink
                {
                    Id=2,
                    Name="Bud"
                },
                new Drink
                {
                    Id=3,
                    Name="Wine"
                }
            };
        }

        public IEnumerable<Drink> GetAll()
        {
            return _drinks.OrderBy(d => d.Name);
        }

        public Drink Get(int id)
        {
            return _drinks.FirstOrDefault(d => d.Id == id);
        }

        public Drink Add(Drink drink)
        {
            drink.Id = _drinks.Max(d => d.Id) + 1;
            _drinks.Add(drink);
            return drink;
        }

        List<Drink> _drinks;
    }
}
