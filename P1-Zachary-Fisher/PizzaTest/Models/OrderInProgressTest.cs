using PizzaLib.Models;
using System.Collections.Generic;
using Xunit;

namespace PizzaTest.Models
{
    public class OrderInProgressTest
    {
        private readonly OrderInProgress _oip = new OrderInProgress();
        [Fact]
        public void Name()
        {
            string a = "Pizza Hut";
            _oip.StoreName = a;
            Assert.Equal(a, _oip.StoreName);
        }
        [Fact]
        public void Pizza()
        {
            {
                Pizza p = new Pizza()
                {
                    Preset = "supreme",
                    Crust = "thin",
                    Size = 6,
                };
                p.setCost();
                _oip.Pizzas = new List<Pizza>();
                _oip.Pizzas.Add(p);
                Assert.Equal(_oip.Pizzas[0], p);
            }
        }
    }
}
