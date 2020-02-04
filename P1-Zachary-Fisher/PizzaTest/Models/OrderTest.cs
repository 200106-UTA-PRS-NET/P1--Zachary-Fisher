using System;
using System.Collections.Generic;
using Xunit;
using PizzaLib.Models;

namespace PizzaTest.Models
{
    public class OrderTest
    {
        private readonly Order _ord = new Order();
        [Fact]
        public void Name()
        {
            string a = "Pizza Hut";
            _ord.Sname = a;
            Assert.Equal(a, _ord.Sname);
        }
        [Fact]
        public void UName()
        {
            string a = "name@place.com";
            _ord.Uname = a;
            Assert.Equal(a, _ord.Uname);
        }
        [Fact]
        public void Time()
        {
            _ord.ordertime = DateTime.MinValue;
            Assert.Equal(DateTime.MinValue, _ord.ordertime);
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
                _ord.pizzas = new List<Pizza>();
                _ord.pizzas.Add(p);
                Assert.Equal(_ord.pizzas[0], p);
            }
        }
    }
}
