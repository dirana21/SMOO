using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class ConsoleResultPrinter : IResultPrinter
    {
        public void Print(Dictionary<string, int> wordStats)
        {
            Console.WriteLine("\nStatistic of word:");
            foreach (var pair in wordStats.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}