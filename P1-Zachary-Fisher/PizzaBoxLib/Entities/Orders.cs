using System;
using System.Collections.Generic;

namespace PizzaBoxData.Entities
{
    public partial class Orders
    {
        public int Orderid { get; set; }
        public string StoreName { get; set; }
        public string UserName { get; set; }
        public decimal? Cost { get; set; }
        public string Pizzas { get; set; }
        public DateTime? Purchasetime { get; set; }

        public virtual Store StoreNameNavigation { get; set; }
    }
}
