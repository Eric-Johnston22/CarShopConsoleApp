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
                "into the store inventory.\nThen you may add cars to the cart.\nFinally, you may checkout, which " +
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
                        Int32 carYear = 0;
                        String isNew = "";
                        Decimal carPrice = 0;

                        Console.WriteLine("What is the car make? ");
                        carMake = stringValidation();

                        Console.WriteLine("What is the car model? ");
                        carModel = stringValidation();

                        Console.WriteLine("What is the car year? ");
                        carYear = intValidation();

                        Console.WriteLine("Is the car new? (y or n)");
                        bool valid = false;
                        do
                        {
                            char input = Console.ReadLine()[0];
                            // Convert upper case to lower case;
                            input = Char.ToLower(input);
                            if (input == 'y')
                            {
                                isNew = "New";
                                valid = true;
                            }
                            else if (input == 'n')
                            {
                                isNew = "Used";
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter either y or n");
                            }
                        } while (!valid);

                        Console.WriteLine("What is the car price? Only numbers please ");
                        carPrice = intValidation();

                        // create a new car object
                        Car newCar = new Car();
                        newCar.Make = carMake;
                        newCar.Model = carModel;
                        newCar.Year = carYear;
                        newCar.IsNew = isNew;
                        newCar.Price = carPrice;
                        CarStore.CarList.Add(newCar);
                        printStoreInventory(CarStore);

                        break;

                    case 2:
                        printStoreInventory(CarStore);

                        int choice = 0;
                        Console.WriteLine("Which car would you like to add to the cart? (number) ");
                        choice = int.Parse(Console.ReadLine());

                        CarStore.ShoppingList.Add(CarStore.CarList[choice]);
                        printShoppingCart(CarStore);

                        break;

                    case 3:
                        printShoppingCart(CarStore);
                        Console.WriteLine("Your total cost is ${0}", CarStore.checkout());

                        break;

                    default:
                        break;

                }
                action = chooseAction();
            }    
        }

        static public string stringValidation()
        {
            bool valid = false;

            do
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a valid string");
                    valid = false;
                }
                else
                {
                    valid = true;
                    return input;
                }
            } while (!valid);

            return null;
        }

        static public int intValidation()
        {
            bool valid = false;
            int i;

            do
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out i))
                {
                    Console.WriteLine("Please enter an integer");
                }
                else
                {
                    valid = true;
                    return i;
                }
            } while (!valid);

            return i;
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
                Console.WriteLine(String.Format("Car # = {0} {1} ", i, c.Display));
                i++;
            }
        }

        static public void printShoppingCart(Store carStore)
        {
            Console.WriteLine("These are the cars in your shopping cart: ");
            int i = 0;
            foreach (var c in carStore.ShoppingList)
            {
                Console.WriteLine(String.Format("Car # = {0} {1} ", i, c.Display));
                i++;
            }
        }
    }
}