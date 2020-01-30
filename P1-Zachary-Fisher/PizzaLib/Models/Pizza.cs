using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Models
{
    public class Pizza
    {
        private string _crust = "thin";
        private int _size = 6;
        private string _preset;
        public string Preset { get; set; }
        public List<string> toppings = new List<string>();

        public Pizza()
        {
            
        }
        public Pizza(string s)
        {
            _preset = s;
            if (s.Equals("hawaiian"))
            {
                toppings = new List<string> { "sauce", "cheese", "pineapple", "canadian bacon" };
            }
            else if (s.Equals("3 meat"))
            {
                toppings = new List<string> { "sauce", "cheese", "sausage", "canadian bacon", "pepperoni" };
            }
            else if (s.Equals("supreme"))
            {
                toppings = new List<string> { "sauce", "cheese", "sausage", "mushroom", "green pepper", "pepperoni" };
            }
            else if (s.Equals("meat lover"))
            {
                toppings = new List<string> { "sauce", "cheese", "sausage", "canadian bacon", "pepperoni", "bacon", "beef" };
            }
            else if (s.Equals("cheeseburger"))
            {
                toppings = new List<string> { "sauce", "cheese", "beef", "pickles", "mushrooms" };
            }
            else if (s.Equals("bacon cheeseburger"))
            {
                toppings = new List<string> { "sauce", "cheese", "beef", "pickles", "mushrooms", "bacon" };
            }
        }

        public decimal Cost { get; set; }
        public string Crust
        {
            get => _crust;
            set
            {
                if (value == "thin" || value == "sicilian" || value == "deep dish")
                {
                    _crust = value;
                    setCost();
                }
            }
        }
        public int Size
        {
            get => _size;
            set
            {
                if (value == 6 || value == 8 || value == 10 || value == 12 || value == 14)
                {
                    _size = value;
                    setCost();
                }
            }
        }
        //(a.Equals("sausage") || a.Equals("pepperoni") || a.Equals("cheese") || a.Equals("bacon") || a.Equals("beef") ||
        //a.Equals("canadian bacon") || a.Equals("mushrooms") || a.Equals("onions") || a.Equals("green peppers") ||
        //        a.Equals("olives") || a.Equals("pineapple") || a.Equals("jalapenos") || a.Equals("sauce")
        
        public string Toppings()
        {
            StringBuilder r = new StringBuilder();
            foreach (string t in toppings)
            {
                r.Append(t);
                r.Append(", ");
            }
            string re = Convert.ToString(r);
            return re;
        }
        public void setCost()
        {
            decimal cost = 0m;
            
            cost += (decimal)(.25 * _size + 2.5);
            foreach (var topping in toppings)
            {
                cost += .25m;
            }
            Cost = cost;
        }
    }
}