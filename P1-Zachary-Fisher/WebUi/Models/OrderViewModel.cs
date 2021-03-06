﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebUi.Models
{
    public class OrderViewModel
    {
        [Display(Name = "ID")]
        public int Orderid { get; set; }
        [Required]
        [Display(Name = "Store")]
        public string StoreName { get; set; }
        public string Username { get; set; }
        [Display(Name = "Cost")]
        public decimal? Cost { get; set; }
        [Display(Name ="Time of Purchase")]
        public DateTime? Purchasetime { get; set; }
        [Display(Name = "Crust")]
        public String pizzas { get; set; }
    }
}
