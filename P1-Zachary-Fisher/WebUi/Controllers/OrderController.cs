using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUi.Models;
using System.Diagnostics;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using PizzaLib.Models;
using PizzaLib.Interfaces;

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


        public ActionResult Create() => View();

        public ActionResult Create([Bind("Name")]OrderViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var order = new Order
                    {
                        Sname = viewModel.StoreName,
                        Uname = User.Identity.Name,
                        Cost = (decimal)viewModel.Cost,
                        pizzas = JsonConvert.DeserializeObject<List<Pizza>>(viewModel.pizzas)
                    };
                    Repo.AddOrder(order);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
