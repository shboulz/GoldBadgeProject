using ChallengeOneRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{
    class Program_UI
    {
        
        private readonly MenuRepo _menuRepo = new MenuRepo();
        public void Run()
        {
            Seed();
            RunApplication();
        }
        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Management System Please Select one of the options below.\n" +
                    "1. Add a new menu item.\n" +
                    "2. Delete a menu item.\n" +
                    "3. List of all menu items.\n" +
                    "4. Exit.");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ViewAllMenuItems();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Enjoy The Rest Of the Shift!");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddNewMenuItem()
        {
            Console.Clear();
            Menu menu = new Menu();

            Console.WriteLine("Welcome to the Menu Creation Tool");

            Console.WriteLine("What is the meal name");
            menu.MealName = Console.ReadLine();

            Console.WriteLine("Please describe the meal");
            menu.MealDiscription = Console.ReadLine();

            Console.WriteLine("What will be the price of the meal");
            menu.MealPrice = double.Parse(Console.ReadLine());



            bool listIngredientsForNewMeal = false;
            List<string> ListOfIngredients = new List<string>();
            while (!listIngredientsForNewMeal)
            {
                Console.WriteLine("Do you want to list the ingredients of the new meal? (yes or no)");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "yes")
                {
                    
                    Console.WriteLine("Type the ingredients and seperate by a comma ( , )");
                    string userTypedIngredients = Console.ReadLine().ToLower();

                    ListOfIngredients.Add(userTypedIngredients);

                }
                else
                {
                    listIngredientsForNewMeal = true;
                }
            }
            
            menu.Ingredients.AddRange(ListOfIngredients);

            bool isSuccessful = _menuRepo.AddNewMenuItem(menu);
            if (isSuccessful)
            {
                Console.WriteLine("Menu item has been added!");
            }
            else
            {
                Console.WriteLine("Menu item not added!");
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            GiveMenuData();
            Console.ReadKey();
            Console.Clear();
        }
        
        private void GiveMenuData()
        {
            List<Menu> menus = _menuRepo.GetMenu();
            foreach (Menu menu in menus)
            {
                ShowMenuDetails(menu);
            }
        }
        private void ShowMenuDetails(Menu menu)
        {
            Console.WriteLine($"Meal Number: {menu.MealNumber}\n" +
                $"Meal Name: {menu.MealName}\n" +
                $"Meal Discription: {menu.MealDiscription}\n" +
                $"Meal Price: {menu.MealPrice}");
            ShowIngredients(menu.Ingredients);
            Console.WriteLine("..............................................................................................");
            
        }

        private void ShowIngredients(List<string> ListOfIngredients)
        {
            
            {
                foreach (string ingredients in ListOfIngredients)
                {
                    Console.WriteLine("Meal ingredients:" + " " + ingredients);
                }
            } 
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            GiveMenuData();
            Console.WriteLine("..............................");

            Console.WriteLine("Please inpt the Meal Number you wish to remove from Menu");
            int userInputMealNumber = int.Parse(Console.ReadLine());

            bool isSuccessful = _menuRepo.DeleteMenuItem(userInputMealNumber);
            if (isSuccessful)
            {
                Console.WriteLine($"Meal with Number: {userInputMealNumber} has been removed successfully!");
            }
            else
            {
                Console.WriteLine("Meal removal failed!");
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void Seed()
        {
            Menu menuA = new Menu(1, "Hummus", "The best thing that will ever enter your mouth ", 2.99, new List<string> { "Chipea, Olive Oil, Tahini, Roasted Garlic" });
            Menu menuB = new Menu(1, "Hamburger", "Simple yet tasty", 5.99, new List<string> { "Tomato, Lettuce, Beef Patty" });
            Menu menuC = new Menu(1, "HotDog", "bun heaven", 12.99, new List<string> { "Beef HotDog, diced onion, bun" });
            Menu menuD = new Menu(1, "Chicken Salad", "Only Healthy Option here", 8.99, new List<string> { "Tomato, Lettuce, Chicken" });
            Menu menuF = new Menu(1, "Cheddar Soup", "yummmmmmmmm", 22.99, new List<string> { "imitation chedder, broth, little love" });

            _menuRepo.AddNewMenuItem(menuA);
            _menuRepo.AddNewMenuItem(menuB);
            _menuRepo.AddNewMenuItem(menuC);
            _menuRepo.AddNewMenuItem(menuD);
            _menuRepo.AddNewMenuItem(menuF);
        

            
        
        }
    }

}
