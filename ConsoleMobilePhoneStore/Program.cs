using System;
using System.Collections.Generic;

namespace ConsoleMobilePhoneStore
{
    public class PhoneStore
    {
        private List<Phone> phones = new List<Phone>();

        public void AddPhone(Phone phone)
        {
            phones.Add(phone);
        }

        public void ShowPhones()
        {
            Console.WriteLine("\nList of available phones:");
            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            PhoneStore store = new PhoneStore();                   
            bool running = true;                                    

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("YodaFon Mobile Phone Store!");
            Console.ResetColor();

            store.AddPhone(new Phone("Galaxy S21", "Samsung", 55000.99m, 10));
            store.AddPhone(new Phone("iPhone 13", "Apple", 105009.99m, 10));
            store.AddPhone(new Phone("Pixel 6", "Google", 32599.99m, 10));

            while (running)
            {
                Console.WriteLine("\n1. Add a phone");
                Console.WriteLine("2. Show phones");
                Console.WriteLine("3. Exit");
                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPhone(store);
                        break;
                    case "2":
                        store.ShowPhones();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect selection. Please try again.");
                        break;
                }
            }
        }

        static void AddPhone(PhoneStore store)
        {
            Console.Write("\nEnter the phone model: ");
            string model = Console.ReadLine();

            Console.Write("Enter the phone brand: ");
            string brand = Console.ReadLine();

            Console.Write("Enter the phone price: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("\nInvalid input. Please enter the price in the correct format (4000.00): ");
            }

            Console.Write("Enter the Quantity: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.Write("\nInvalid input. Please enter an integer for the number of: ");
            }

            Phone newPhone = new Phone(model, brand, price, quantity);
            store.AddPhone(newPhone);
            Console.WriteLine("Phone number added successfully");
        }
    }

    public class Phone
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Phone(string model, string brand, decimal price, int quantity)
        {
            Model = model;
            Brand = brand;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Brand} {Model} - price: {Price:C2}, quantity - {Quantity} pc.";
        }
    }
}