using System;
using Xunit;
using PizzaLib.Models;

namespace PizzaTest
{
    public class StoreTest
    {
        private readonly Store _store = new Store();
        [Fact]
        public void Name()
        {
            string a = "Pizza Hut";
            _store.SName = a;
            Assert.Equal(a, _store.SName);
        }
        [Fact]
        public void Password()
        {
            {
                string a = "Pizza Hut";
                _store.Password = a;
                Assert.Equal(a, _store.Password);
            }
        }
    }
}
