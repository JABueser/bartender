using bartender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.Services
{
    public interface IDrinkData
    {
        IEnumerable<Drink> GetAll();
        Drink Get(int id);
        Drink Add(Drink drink);
        void Save(Drink drink);
        Drink Delete(int Id);
    }
}
