using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Store
    {
        public List<Car> CarList { get; set; }
        public List<Car> ShoppingList { get; set; }

        public Store()
        {
            CarList = new List<Car>();
            ShoppingList = new List<Car>();
        }

        public decimal checkout()
        {
            decimal totalCost = 0;

            // calculate the total cost of items in cart
            foreach (var c in ShoppingList)
            {
                totalCost += c.Price;
            }

            // clear shopping cart
            ShoppingList.Clear();

            // return the total
            return totalCost;
        }
    }
}
