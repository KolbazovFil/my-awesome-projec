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
            Console.WriteLine("\nСписок доступных телефонов:");
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
            Console.OutputEncoding = System.Text.Encoding.UTF8;     // Кодировка
            PhoneStore store = new PhoneStore();                    // Создание объекта store класса PhoneStore()
            bool running = true;                                    // флаг

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Салон сотовой связи ЙодаФон!");
            Console.ResetColor();

            // Записую 3 модели телефона в List<Phone>
            store.AddPhone(new Phone("Galaxy S21", "Samsung", 55000.99m, 10));
            store.AddPhone(new Phone("iPhone 13", "Apple", 105009.99m, 10));
            store.AddPhone(new Phone("Pixel 6", "Google", 32599.99m, 10));

            while (running)
            {
                Console.WriteLine("\n1. Добавить телефон");
                Console.WriteLine("2. Показать телефоны");
                Console.WriteLine("3. Выйти");
                Console.Write("\nВыберите опцию: ");

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
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }

        static void AddPhone(PhoneStore store)
        {
            Console.Write("\nВведите модель телефона: ");
            string model = Console.ReadLine();

            Console.Write("Введите бренд телефона: ");
            string brand = Console.ReadLine();

            Console.Write("Введите цену телефона: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("\nНеверный ввод. Пожалуйста, введите цену в правильном формате (4000,00): ");
            }

            Console.Write("Введите Количество: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.Write("\nНеверный ввод. Пожалуйста, введите целочисленное число для кол-во: ");
            }

            Phone newPhone = new Phone(model, brand, price, quantity);
            store.AddPhone(newPhone);
            Console.WriteLine("Телефон добавлен успешно");
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
            return $"{Brand} {Model} - цена: {Price:C2}, кол-во - {Quantity} шт.";
        }
    }
}