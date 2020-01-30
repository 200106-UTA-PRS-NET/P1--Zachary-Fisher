using Microsoft.Extensions.Logging;
using PizzaBoxData.Entities;
using PizzaLib.Interfaces;
using PizzaLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxData.Repositories
{
    class RepositoryPizza : IRepositoryPizza
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
            _logger.LogInformation("Adding restaurant");

            Orders entity = Mapper.Map(order);
            _dbContext.Add(entity);
        }

        public List<Order> GetOrderbyStore(string sName)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrderbyUser(string uName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PizzaLib.Models.Store> GetStores()
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            _logger.LogInformation("Saving changes to the database");
            _dbContext.SaveChanges();
        }
    }
}
