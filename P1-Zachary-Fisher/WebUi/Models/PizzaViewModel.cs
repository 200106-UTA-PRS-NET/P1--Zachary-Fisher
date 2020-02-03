using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.Models
{
    public class PizzaViewModel
    {
        [Required]
        public string Crust { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string Preset { get; set; }
    }
}
