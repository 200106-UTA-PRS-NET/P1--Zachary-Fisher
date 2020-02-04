using Microsoft.Extensions.Logging;
using PizzaBoxData.Entities;
using PizzaLib.Interfaces;
using PizzaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBoxData.Repositories
{
    public class RepositoryPizza : IRepositoryPizza
    {
        private readonly PizzaDbWebContext _dbContext;

        private readonly ILogger<RepositoryPizza> _logger;


        public RepositoryPizza(PizzaDbWebContext dbContext, ILogger<RepositoryPizza> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddOrder(PizzaLib.Models.Order order)
        {
            _logger.LogInformation("Adding order");

            Orders entity = Mapper.Map(order);
            _dbContext.Add(entity);
        }

        public void AddTempOrder(PizzaLib.Models.OrderInProgress o)
        {
            _logger.LogInformation(o.StoreName);
            _logger.LogInformation($"num pizzas:{o.Pizzas.Count}");
            _logger.LogInformation("Adding Temp Order");
            Entities.OrderInProgress entity = Mapper.Map(o);
            Console.WriteLine(entity.Pizzas);
            _dbContext.Add(entity);
        }

        public PizzaLib.Models.OrderInProgress GetTempOrder()
        {
            PizzaLib.Models.OrderInProgress o = Mapper.Map(_dbContext.OrderInProgress.AsEnumerable().Last());
            _logger.LogInformation($"Getting Temp Order (Store name{o.StoreName})");
            return o;
        }

        public void ClearTempOrders()
        {
            _logger.LogInformation("Clearing Temp Data");
            int i = 0;
            while(_dbContext.OrderInProgress.Count() > 0)
            {
                _dbContext.OrderInProgress.Remove(_dbContext.OrderInProgress.First());
                i++;
                if (i > 5) { break; }
            }
        }

        public List<Order> GetOrderbyStore(string sName)
        {
            IQueryable<Orders> items = _dbContext.Orders;

            items = items.Where(x => x.StoreName == sName);

            return items.Select(Mapper.Map).ToList();
        }

        public List<Order> GetOrderbyUser(string uName)
        {
            IQueryable<Orders> items = _dbContext.Orders;
            
            items = items.Where( x=> x.UserName == uName);
            
            return items.Select(Mapper.Map).ToList();
        }
        public IEnumerable<PizzaLib.Models.Store> GetStores()
        {
            IQueryable<Entities.Store> items = _dbContext.Store;
            return items.Select(Mapper.Map); 
        }
        public void Save()
        {
            _logger.LogInformation("Saving changes to the database");
            _dbContext.SaveChanges();
        }
    }
}
