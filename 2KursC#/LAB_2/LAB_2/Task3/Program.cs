using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ICompanyRepository repo = InMemoryCompanyRepository.CreateDemo();
            ICompanyQueryService qs = new CompanyQueryService(repo);
            
            ConsolePrinter.PrintLine("Number of employees (all)", qs.EmployeesCountTotal());
            ConsolePrinter.PrintLine("Number of workers (Worker)", qs.WorkersCountOnly());
            
            ConsolePrinter.PrintLine("Total payroll (salaries)", qs.TotalPayroll().ToString("0.##"));
            
            ConsolePrinter.PrintCollection("Top 10 workers by length of service", qs.Top10MostExperiencedWorkers());
            var youngestEdu = qs.YoungestWithHigherEducationAmongTop10();
            ConsolePrinter.PrintLine("The youngest with a higher education among the top 10",
                youngestEdu != null ? youngestEdu.ToString() : "—");
            
            ConsolePrinter.PrintLine("The youngest manager", ConsolePrinter.EmployerShort(qs.YoungestManager()));
            ConsolePrinter.PrintLine("The most senior manager", ConsolePrinter.EmployerShort(qs.OldestManager()));
            
            ConsolePrinter.PrintOctoberGroups(qs.OctoberBornWorkersBySpecialty());
            
            ConsolePrinter.PrintCollection("All Volodymyrs", qs.AllNamedVolodymyr());
            var youngestVol = qs.YoungestVolodymyr();
            ConsolePrinter.PrintLine("The youngest Volodymyr", ConsolePrinter.EmployerShort(youngestVol));
            ConsolePrinter.PrintLine("Bonus (1/3 salary) to the youngest Volodymyr", qs.YoungestVolodymyrBonusAmount().ToString("0.##"));

            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();
        }
    }
}