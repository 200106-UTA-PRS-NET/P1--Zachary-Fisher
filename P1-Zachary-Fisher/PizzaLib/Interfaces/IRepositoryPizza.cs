﻿using PizzaLib.Models;
using System.Collections.Generic;

namespace PizzaLib.Interfaces
{
    public interface IRepositoryPizza
    {
        IEnumerable<Store> GetStores();
        List<Order> GetOrderbyUser(string uName);
        List<Order> GetOrderbyStore(string sName);
        void AddOrder(Order order);
        void AddTempOrder(OrderInProgress o);
        void ClearTempOrders();
        void Save();
        OrderInProgress GetTempOrder();
    }
}