using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBoxData.Entities
{
    public partial class OrderInProgress
    {
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string Pizzas { get; set; }
    }
}
