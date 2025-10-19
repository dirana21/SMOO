using System;
using System.Collections.Generic;

namespace Task1
{
    public static class ConsolePrinter
    {
        public static void Print(string title, IEnumerable<Firm> firms)
        {
            Console.WriteLine($"\n=== {title} ===");
            foreach (var firm in firms)
                Console.WriteLine(firm);
        }
    }
}