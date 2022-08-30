
/*Program Objective: To demonstrate-
      1.Define a class with suitable access modifiers.
      2.Creating a instance of a class
      3.Create a List
      4.Create methods to add,save,search records in the list
      5.Creating a JSON file and string data in the file

REUSING METHODS:Savedata() method has been resued for storing data in pizza list and pasta list.
INHERITANCE : Eat() class is the parent class for Pasta and Pizza class .

*/

using System;

namespace GastronomiaPizzeria
{
    internal class Gui
    {
        private Data data = new Data();
       
        private string path = @"/Users/ramyakailashnathan/Desktop/Gastromanio_Menu.json";
        public Gui()
        {
            
            while (true)
            {
                Menu();
            }
        }
        #region Main Menu
        private void Menu()
        {
            Console.WriteLine("\n\t\tGASTRONIMIA PIZZERIA MAIN MENU\n\t\t\t1 for Pizza\n\t\t\t2 for Pasta\n\t\t\t3 for Save Data");
            Console.WriteLine("\n\t\t______________________________");
            Console.Write("Enter your menu choice:: ");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    PizzaMenu();
                    break;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    PastaMenu();
                    break;
                
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    SaveData();
                    break;
                
                default:
                    break;
            }
        }
        #endregion Main Menu

        #region SaveData (re-used for both PIZZA class and PASTA class)
        private void SaveData()
        {
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path, json);
            Console.WriteLine("Food File is saved in the location:: " + path);
        }

        
        #endregion

        #region Pizza
        private void PizzaMenu()
        {

            Console.WriteLine("\n\t\tPIZZA MENU\n\t\t\t5 Add Pizza to the menu\n\t\t\t6 Search for a Pizza\n\t\t\t7 Show all Pizzas ");
            Console.WriteLine("\n\t\t__________");
            Console.Write("Enter your choice for Pizza:: ");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    AddPizza();
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    SearchPizza();
                    break;
                case ConsoleKey.NumPad7:
                case ConsoleKey.D7:
                    ShowPizzaList();
                    break;
                default:
                    break;
            }

        }
        //This method is used to add pizza (name,size and toppings) onto the Pizza list
        private void AddPizza()
        {
            Pizza pizza = new Pizza();
            Console.Write("\n\t\t\tEnter Pizza Name: ");
            string pizza_name = Console.ReadLine();
            pizza.Name = pizza_name;
            Console.Write("\t\t\tEnter Pizza Size: ");
            string pizza_size = Console.ReadLine();
            pizza.Size = pizza_size;
            Console.Write("\t\t\tEnter Pizza Toppings: ");
            string pizza_toppings = Console.ReadLine();
            pizza.Toppings = pizza_toppings;

            Console.Write("Would you like to add the pizza to the Pizza list(Y/N)? ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
                data.PizzaList.Add(pizza);
            //Console.WriteLine(pizza.Name,pizza.Size,pizza.Toppings);
            Console.Clear();

        }
        //This method is used to show the contents of the list in Pizza list
        private void ShowPizza(Pizza pz)
        {
            Console.WriteLine("\n\t\t_______________________________________________");
            Console.WriteLine($"\n\t\t\t{pz.Name} {pz.Size} {pz.Toppings}");
            Console.WriteLine("\n\t\t_______________________________________________");
        }
        //This method is used to check if the list is empty and output suitable error messages
        private void ShowPizzaList()
        {
            if (data.PizzaList == null || data.PizzaList.Count == 0)
            {
                Console.WriteLine("\n\t\tOops!!The Pizza list is empty!");
                return;
            }
            
            Console.WriteLine("\n\t\t Pizza Details");
            foreach (Pizza pz in data.PizzaList)
            {
                ShowPizza(pz);
            }
            
        }
        //This method is used to search for a pizza in the pizza list 
        private void SearchPizza()
        {
            Console.Write("\t\tWhich pizza would you like to search?  ");
            string? search_pizza = Console.ReadLine();
            foreach (Pizza pizza in data.PizzaList)
            {
                if (search_pizza != null)
                {
                    if (pizza.Name.ToLower().Contains(search_pizza))
                    {
                        Console.WriteLine("\t\t Pizza found in the list.");
                        ShowPizza(pizza);
                    }
                    else
                    {
                        Console.WriteLine("\t\t Pizza NOT found in the list.");
                    }
                        
                }
            }
        }
        
        #endregion Pizza

        #region Pasta
        private void PastaMenu()
        {

            Console.WriteLine("\n\t\tPASTA MENU\n\t\t\t5 Add Pasta to the menu\n\t\t\t6 Search for a Pasta\n\t\t\t7 Show all Pastas");
            Console.Write("Enter your choice for Pasta:: ");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    AddPasta();
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    SearchPasta();
                    break;
                case ConsoleKey.NumPad7:
                case ConsoleKey.D7:
                    ShowPastaList();
                    break;
                default:
                    break;
            }

        }

        //This method is used to add pasta (name,size and toppings) onto the Pasta list

        private void AddPasta()
        {
            Pasta pasta = new Pasta();
            Console.Write("\n\t\t\tEnter Pasta Name: ");
            string pasta_name = Console.ReadLine();
            pasta.Name = pasta_name;
            Console.Write("\n\t\t\tEnter Pasta Size: ");
            string pasta_size = Console.ReadLine();
            pasta.Size = pasta_size;
            Console.Write("\n\t\t\tEnter Pasta Toppings: ");
            string pasta_toppings = Console.ReadLine();
            pasta.Toppings = pasta_toppings;

            Console.Write("Would you like to add the pasta to the Pasta list(Y/N)? ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
                data.PastaList.Add(pasta);
            
            Console.Clear();
        }
        //This method is used to show the contents of the Pasta list
        private void ShowPasta(Pasta ps)
        {
            Console.WriteLine("\n\t\t_______________________________________________");
            Console.WriteLine($"\n\t\t\t{ps.Name} {ps.Size} {ps.Toppings}");
            Console.WriteLine("\n\t\t_______________________________________________");
        }
        
        private void ShowPastaList()
        {
            if (data.PastaList == null || data.PastaList.Count == 0)
            {
                Console.WriteLine("\n\t\tOops!!The Pasta list is empty!");
                return;
            }

            Console.WriteLine("\n\t\t Pasta Details");
            foreach (Pasta ps in data.PastaList)
            {
                ShowPasta(ps);
            }

        }

        //This method is used to search for a pasta in the pasta list 
        private void SearchPasta()
        {
            Console.Write("\t\tWhich pasta would you like to search?  ");
            string? search_pasta = Console.ReadLine();
            foreach (Pasta pasta in data.PastaList)
            {
                if (search_pasta != null)
                {
                    if (pasta.Name.ToLower().Contains(search_pasta))
                    {
                        Console.WriteLine("\t\t Pasta found in the list.");
                        ShowPasta(pasta);
                    }
                    else
                    {
                        Console.WriteLine("\t\t Pasta was NOT found in the list.");
                    }

                }
            }
        }
       
        #endregion Pasta
    }
}
