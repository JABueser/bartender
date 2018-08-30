using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bartender.Data;
using bartender.Models;

namespace bartender.Services
{
    public class SqlDrinkData : IDrinkData
    {
        private BartenderDbContext _context;

        public SqlDrinkData(BartenderDbContext context)
        {
            _context = context;
        }

        public Drink Add(Drink drink)
        {
            _context.Drinks.Add(drink);
            _context.SaveChanges();
            return drink;
        }

        public Drink Get(int id)
        {
            return _context.Drinks.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Drink> GetAll()
        {
            return _context.Drinks.OrderBy(d => d.Name);
        }

        public void Save(Drink drink)
        {
            if (drink.Id == 0)
            {
                _context.Drinks.Add(drink);
            }
            else
            {
                Drink dbEntry = _context.Drinks.FirstOrDefault(d => d.Id == drink.Id);
                if (dbEntry != null)
                {
                    dbEntry.Description = drink.Description;
                    dbEntry.Name = drink.Name;
                    dbEntry.Image = drink.Image;
                    dbEntry.Price = drink.Price;
                }
            }
            _context.SaveChanges();
        }

        public Drink Delete(int Id)
        {
            Drink dbEntry = _context.Drinks.FirstOrDefault(d => d.Id == Id);
            if (dbEntry != null)
            {
                _context.Drinks.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }


    }
}
