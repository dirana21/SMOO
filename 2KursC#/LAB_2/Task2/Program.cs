using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var seed = new List<Phone>
            {
                new Phone("iPhone 13", "Apple", 799, new DateTime(2021, 9, 24)),
                new Phone("iPhone 10", "Apple", 499, new DateTime(2017, 11, 3)),
                new Phone("iPhone 13", "Apple", 829, new DateTime(2021, 10, 1)),
                new Phone("Galaxy S22", "Samsung", 749, new DateTime(2022, 2, 25)),
                new Phone("Galaxy S22", "Samsung", 699, new DateTime(2022, 3, 10)),
                new Phone("Galaxy S21", "Samsung", 599, new DateTime(2021, 1, 29)),
                new Phone("Xperia 5 III", "Sony", 699, new DateTime(2021, 10, 1)),
                new Phone("Xperia 1 IV", "Sony", 999, new DateTime(2022, 6, 11)),
                new Phone("Pixel 7", "Google", 599, new DateTime(2022, 10, 13)),
                new Phone("Pixel 6a", "Google", 449, new DateTime(2022, 7, 28)),
                new Phone("Redmi Note 10", "Xiaomi", 199, new DateTime(2021, 3, 16)),
                new Phone("Mi 11", "Xiaomi", 699, new DateTime(2021, 1, 1)),
                new Phone("iPhone 15 Pro", "Apple", 999, new DateTime(2023, 9, 22)),
                new Phone("Galaxy S24", "Samsung", 999, new DateTime(2024, 1, 31)),
                new Phone("Xperia 5 V", "Sony", 899, new DateTime(2023, 9, 15))
            };

            IPhoneRepository repo = new InMemoryPhoneRepository(seed);
            IPhoneQueryService qs = new PhoneQueryService(repo);

            
            ConsolePrinter.PrintLine("Number of phones", qs.CountAll());
            ConsolePrinter.PrintLine("Quantity with price > 100", qs.CountPriceGreaterThan(100));
            ConsolePrinter.PrintLine("Quantity with price 400..700", qs.CountPriceInRange(400, 700));
            ConsolePrinter.PrintLine("Manufacturer quantity Samsung", qs.CountByManufacturer("Samsung"));

            
            ConsolePrinter.PrintLine("Min. phone price", (object)qs.MinPricePhone() ?? "—");
            ConsolePrinter.PrintLine("Max. phone price", (object)qs.MaxPricePhone() ?? "—");
            ConsolePrinter.PrintLine("The oldest phone", (object)qs.OldestPhone() ?? "—");
            ConsolePrinter.PrintLine("The latest phone", (object)qs.NewestPhone() ?? "—");

            
            ConsolePrinter.PrintLine("Average price", qs.AveragePrice()?.ToString("0.##") ?? "—");

            
            ConsolePrinter.PrintPhones("5 the most expensive", qs.TopMostExpensive(5));
            ConsolePrinter.PrintPhones("5 the cheapest", qs.TopCheapest(5));
            ConsolePrinter.PrintPhones("3 the oldest", qs.TopOldest(3));
            ConsolePrinter.PrintPhones("3 the newest", qs.TopNewest(3));

            
            ConsolePrinter.PrintStats("Statistics by manufacturers", qs.ManufacturerStats());
            ConsolePrinter.PrintStats("Statistics by models", qs.ModelStats());
            ConsolePrinter.PrintStats("Statistics by year", qs.YearStats());

            Console.WriteLine("\nDone. Press any key to exit....");
            Console.ReadKey();
        }
    }
}