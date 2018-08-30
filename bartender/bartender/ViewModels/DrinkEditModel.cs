using bartender.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.ViewModels
{
    public class DrinkEditModel
    {
        public int Id { get; set; }

        [Display(Name = "Drink Name")]
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
