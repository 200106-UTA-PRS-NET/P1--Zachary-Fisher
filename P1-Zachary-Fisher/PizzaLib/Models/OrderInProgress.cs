using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Models
{
    public class OrderInProgress
    {
        public string StoreName { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
