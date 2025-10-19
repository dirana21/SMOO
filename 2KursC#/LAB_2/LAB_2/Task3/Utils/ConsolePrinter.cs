using System;
using System.Collections.Generic;

namespace Task3
{
    public static class ConsolePrinter
    {
        public static void PrintLine(string title, object value)
        {
            Console.WriteLine($"{title}: {value}");
        }

        public static void PrintCollection<T>(string title, IEnumerable<T> items)
        {
            Console.WriteLine($"\n=== {title} ===");
            foreach (var x in items) Console.WriteLine(x);
        }

        public static void PrintOctoberGroups(IDictionary<WorkerSpecialty, List<Worker>> dict)
        {
                Console.WriteLine("\n=== October birthdays (by specialization) ===");
            foreach (var kv in dict)
            {
                Console.WriteLine($"[{kv.Key}]");
                foreach (var w in kv.Value)
                {
                    Console.WriteLine($"  - {w.LastName} {w.FirstName} | DOB: {w.BirthDate:yyyy-MM-dd} | Salary: {w.BaseSalary:0.##}");
                }
            }
        }

        public static string EmployerShort(Employer e)
            => e == null ? "—" : $"{e.GetType().Name}: {e.LastName} {e.FirstName} (DOB {e.BirthDate:yyyy-MM-dd}, Salary {e.BaseSalary:0.##})";
    }
}