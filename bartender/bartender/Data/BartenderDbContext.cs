using bartender.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.Data
{
    public class BartenderDbContext : DbContext
    {
        public BartenderDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
