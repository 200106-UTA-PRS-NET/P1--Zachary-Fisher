using System.ComponentModel.DataAnnotations;

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
