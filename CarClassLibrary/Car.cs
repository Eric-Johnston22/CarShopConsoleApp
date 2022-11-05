using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        // Car constructor with 3 parameters
        public Car(string make, string model, decimal price)
        {
            Make = make;
            Model = model;
            Price = price;
        }

        // Default constructor
        public Car()
        {
            Make = "Nothing yet";
            Model = "Nothing yet";
            Price = 0;
        }

        public string Display
        {
            get
            {
                return string.Format("{0} {1} ${2}", Make, Model, Price);
            }
        }
    }
}
