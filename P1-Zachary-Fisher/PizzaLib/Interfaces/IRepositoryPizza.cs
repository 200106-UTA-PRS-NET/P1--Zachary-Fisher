using PizzaLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Interfaces
{
    public interface IRepositoryPizza
    {
        IEnumerable<Store> GetStores();
        IEnumerable<Order> GetOrders();
        List<Order> GetOrderbyUser(string uName);
        List<Order> GetOrderbyStore(string sName);
        void AddOrder(Order order);
        void Save();
    }
}