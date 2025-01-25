// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace Mission03
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<FoodItem> foodInventory = new List<FoodItem>();
            int choice;

            do
            {
                Console.WriteLine("\nFood Bank Inventory System");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please select a valid option (1-4).");
                    Console.Write("Enter your choice: ");
                }

                switch (choice)
                {
                    case 1:
                        AddFoodItem(foodInventory);
                        break;
                    case 2:
                        DeleteFoodItem(foodInventory);
                        break;
                    case 3:
                        PrintFoodItems(foodInventory);
                        break;
                    case 4:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                }
            } while (choice != 4);
        }

        static void AddFoodItem(List<FoodItem> inventory)
        {
            Console.Write("Enter food name: ");
            string name = Console.ReadLine();

            Console.Write("Enter food category: ");
            string category = Console.ReadLine();

            Console.Write("Enter quantity: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a non-negative number.");
                Console.Write("Enter quantity: ");
            }

            Console.Write("Enter expiration date (yyyy-mm-dd): ");
            DateTime expirationDate;
            while (!DateTime.TryParse(Console.ReadLine(), out expirationDate) || expirationDate < DateTime.Now)
            {
                Console.WriteLine("Invalid date. Please enter a valid future date.");
                Console.Write("Enter expiration date (yyyy-mm-dd): ");
            }

            inventory.Add(new FoodItem(name, category, quantity, expirationDate));
            Console.WriteLine("Food item added successfully.");
        }

        static void DeleteFoodItem(List<FoodItem> inventory)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("The inventory is empty. Nothing to delete.");
                return;
            }

            Console.WriteLine("\nCurrent Food Items:");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[i]}");
            }

            Console.Write("Enter the number of the item to delete: ");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > inventory.Count)
            {
                Console.WriteLine("Invalid choice. Please select a valid item number.");
                Console.Write("Enter the number of the item to delete: ");
            }

            inventory.RemoveAt(index - 1);
            Console.WriteLine("Food item deleted successfully.");
        }

        static void PrintFoodItems(List<FoodItem> inventory)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("The inventory is empty.");
                return;
            }

            Console.WriteLine("\nCurrent Food Items:");
            foreach (var item in inventory)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class FoodItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return $"{Name} ({Category}), Quantity: {Quantity}, Expiration Date: {ExpirationDate:yyyy-MM-dd}";
        }
    }
}

