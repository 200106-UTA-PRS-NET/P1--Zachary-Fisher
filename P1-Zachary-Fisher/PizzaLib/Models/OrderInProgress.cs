using System.Collections.Generic;

namespace PizzaLib.Models
{
    public class OrderInProgress
    {
        public string StoreName { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
