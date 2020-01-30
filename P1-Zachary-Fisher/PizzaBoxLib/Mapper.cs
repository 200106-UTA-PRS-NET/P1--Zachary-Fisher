using PizzaBoxData.Entities;
using PizzaLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PizzaBoxData
{
    class Mapper
    {
        public static Order Map(Orders o)
        {
            return new Order
            {
                ordertime = (DateTime)o.Purchasetime,
                Sname = o.StoreName,
                Uname = o.UserName,
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(o.Pizzas),
                Cost = (decimal)o.Cost
                
            };
        }
        public static Orders Map(Order o)
        {
            return new Orders
            {
                Purchasetime = o.ordertime,
                StoreName = o.Sname,
                UserName = o.Uname,
                Pizzas = JsonConvert.SerializeObject(o.pizzas),
                Cost = o.Cost
            };
        }
        public static PizzaBoxData.Entities.Store Map(PizzaLib.Models.Store s)
        {
            List<Order> z = s.orders;
            List<Orders> p = new List<Orders>();
            foreach (var o in z)
            {
                p.Add(Map(o));
            }
            return new PizzaBoxData.Entities.Store
            {
                 Name = s.SName,
                 Orders = p,
                 Password = s.Password
            };
        }
        public static PizzaLib.Models.Store Map(PizzaBoxData.Entities.Store s)
        {
            List<Order> p = new List<Order>();
            if (s.Orders != null)
            {
                ICollection<Orders> v = s.Orders;
                foreach (var o in v)
                {
                    p.Add(Map(o));

                }
            }
            return new PizzaLib.Models.Store
            {
                 SName = s.Name,
                 Password =s.Password,
                 orders = p
            };
        }
        public static PizzaLib.Models.OrderInProgress Map(PizzaBoxData.Entities.OrderInProgress p)
        {
            return new PizzaLib.Models.OrderInProgress
            {
                Pizzas = JsonConvert.DeserializeObject<List<Pizza>>(p.Pizzas),
                StoreName = p.StoreName
            };
        }
        public static Entities.OrderInProgress Map(PizzaLib.Models.OrderInProgress p)
        {
            return new Entities.OrderInProgress
            {
                Pizzas = JsonConvert.SerializeObject(p.Pizzas),
                StoreName = p.StoreName
            };
        }
    }
}
