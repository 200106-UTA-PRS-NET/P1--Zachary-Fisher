using Microsoft.AspNetCore.Mvc;
using WebUi.Models;
using System.Diagnostics;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using PizzaLib.Models;
using PizzaLib.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebUi.Controllers
{
    public class OrderController:Controller
    {
        public IRepositoryPizza Repo { get; }
        public OrderController(IRepositoryPizza repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult OrderDetails() 
        {
            var order = Repo.GetTempOrder();
            PizzaLib.Models.OrderInProgress ord = new PizzaLib.Models.OrderInProgress();
            ord.StoreName = order.StoreName;
            ord.Pizzas = order.Pizzas;
            return View(ord);
        }
        public ActionResult FinalizeOrder()
        {
            var order = Repo.GetTempOrder();
            PizzaLib.Models.OrderInProgress ord = new PizzaLib.Models.OrderInProgress();
            ord.StoreName = order.StoreName;
            ord.Pizzas = order.Pizzas;
            return View(ord);
        }
        public ActionResult Finalize()
        {
            OrderInProgress o = Repo.GetTempOrder();
            decimal c = 0;
            for(int i = 0; i < o.Pizzas.Count; i++)
            {
                o.Pizzas[i].setCost();
                c += o.Pizzas[i].Cost;
            }
            PizzaLib.Models.Order ord = new Order()
            {
                Cost = c,
                ordertime = DateTime.Now,
                Sname = o.StoreName,
                Uname = User.Identity.Name,
                pizzas = o.Pizzas
            };
            Repo.AddOrder(ord);
            Repo.Save();

            return RedirectToAction(nameof(Index));

        }
        public ActionResult AddPizza() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPizza(PizzaViewModel p, IFormCollection form)
        {
            Pizza pi = new Pizza(p.Preset)
            {
                Crust = p.Crust,
                Size = p.Size,
                Preset = p.Preset
            };
            pi.setCost();
            OrderInProgress o = Repo.GetTempOrder();
            o.Pizzas.Add(pi);
            Repo.ClearTempOrders();
            Repo.AddTempOrder(o);
            Repo.Save();
            return RedirectToAction(nameof(OrderDetails));
        }
        public ActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Create(OrderInProgress order, IFormCollection form)
        {
            Repo.ClearTempOrders();
            Repo.Save();
            PizzaLib.Models.OrderInProgress o = new OrderInProgress()
            {
                StoreName = order.StoreName,
                Pizzas = new List<Pizza>()
            };
            Repo.AddTempOrder(o);
            Repo.Save();
            return RedirectToAction(nameof(AddPizza));   
        }
        public ActionResult ViewOrders()
        {
            var orders = Repo.GetOrderbyUser(User.Identity.Name);
            List<OrderViewModel> ovm = new List<OrderViewModel>();
            foreach (var item in orders)
            {
                OrderViewModel ord = new OrderViewModel();
                ord.StoreName = item.Sname;
                ord.Purchasetime = item.ordertime;
                ord.pizzas = JsonConvert.SerializeObject(item.pizzas);
                ord.Cost = item.Cost;
                ovm.Add(ord);
            }
            return View(ovm);
        }
        public ActionResult ViewOrdersStore() => View();
        public ActionResult ViewOrdersByStore(StoreInputModel s, IFormCollection form)
        {
            Store st = new Store()
            {
                SName = s.SName
            };
            var orders = Repo.GetOrderbyStore(st.SName);
            Console.WriteLine(st.SName);
            List<OrderViewModel> ovm = new List<OrderViewModel>();
            foreach (var item in orders)
            {
                OrderViewModel ord = new OrderViewModel();
                ord.StoreName = item.Sname;
                ord.Purchasetime = item.ordertime;
                ord.pizzas = JsonConvert.SerializeObject(item.pizzas);
                ord.Cost = item.Cost;
                ovm.Add(ord);
            }
            return View(ovm);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
