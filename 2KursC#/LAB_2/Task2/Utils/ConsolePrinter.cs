using System;
using System.Collections.Generic;

namespace Task2
{
    public static class ConsolePrinter
    {
        public static void PrintPhones(string title, IEnumerable<Phone> phones)
        {
            Console.WriteLine($"\n=== {title} ===");
            foreach (var p in phones) Console.WriteLine(p);
        }

        public static void PrintLine(string title, object value)
        {
            Console.WriteLine($"{title}: {value}");
        }

        public static void PrintStats<T>(string title, IEnumerable<T> items)
        {
            Console.WriteLine($"\n=== {title} ===");
            foreach (var x in items) Console.WriteLine(x);
        }
    }
}