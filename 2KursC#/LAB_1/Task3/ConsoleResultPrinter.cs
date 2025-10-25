using System;
using System.Collections.Generic;

namespace Task3
{
    public class ConsoleResultPrinter : IResultPrinter
    {
        public void Print(IEnumerable<PrintJob> jobs)
        {
            Console.WriteLine("\n--- Print statistics ---");
            foreach (var job in jobs)
                Console.WriteLine(job);
        }
    }
}