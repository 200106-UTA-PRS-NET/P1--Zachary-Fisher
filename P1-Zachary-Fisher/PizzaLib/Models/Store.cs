using System.Collections.Generic;

namespace PizzaLib.Models
{
    public class Store
    {
        public string SName { get; set; }
        public string Password { get; set; }
        public List<Order> orders;
        public Store()
        {

        }
        public Store(string sName, string password)
        {
            Password = password;
            SName = sName;
        }
    }
}
