using bartender.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.ViewModels
{
    public class DrinkEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public AlchoholLevel Alchohol { get; set; }
    }
}
