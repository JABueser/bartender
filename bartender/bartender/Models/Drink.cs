using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bartender.Models
{
    public class Drink
    {
        public int Id { get; set; }

        [Display(Name="Drink Name")]
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public AlchoholLevel Alchohol { get; set; }
    }
}
