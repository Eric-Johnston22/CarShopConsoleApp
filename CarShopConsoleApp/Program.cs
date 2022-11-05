using System;
using System.Security.AccessControl;
using CarClassLibrary;

namespace CarShopConsoleApp
{
    class Program
    {
        static Store CarStore = new Store();

        static void Main(string[] args)
        {
            Console.Out.WriteLine("Welcome to the car store. First you must create some cars and put them " +
                "into the store inventory. Then you may add cars to the cart. Finally, you may checkout, which " +
                "will calculate your total bill.");

            int action = chooseAction();
            while (action != 0)
            {
                switch(action)
                {
                    case 1:
                        Console.WriteLine("You chose to add a new car to the store: ");

                        String carMake = "";
                        String carModel = "";
                        Decimal carPrice = 0;

                        Console.WriteLine("What is the car make? ");
                        carMake = Console.ReadLine();

                        Console.WriteLine("What is the car model? ");
                        carModel = Console.ReadLine();

                        Console.WriteLine("What is the car price? Only numbers please ");
                        carPrice = int.Parse(Console.ReadLine());

                        // create a new car object
                        Car newCar = new Car();
                        newCar.Make = carMake;
                        newCar.Model = carModel;
                        newCar.Price = carPrice;
                        CarStore.CarList.Add(newCar);
                        print

                }
            }    
        }

        static public int chooseAction()
        {
            int choice = 0;
            Console.WriteLine("Choose an action (0) quit (1) add a car (2) add item to cart (3) checkout ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }

        static public void printStoreInventory(Store carStore)
        {
            Console.WriteLine("These are the cars in the store inventory: ");
            int i = 0;
            foreach (var c in carStore.CarList)
            {
                Console.WriteLine(String.Format("Car # = {0} {1} "), i, c.Display);
            }
        }
    }
}