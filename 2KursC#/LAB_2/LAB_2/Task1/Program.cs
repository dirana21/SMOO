using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var firms = new[]
            {
                new Firm("Food", DateTime.Today.AddYears(-5), BusinessProfile.FoodIndustry,
                    new Person("Emma", "White"), 120, new Address("UK", "London", "221B Baker St")),

                new Firm("White & Black IT", DateTime.Today.AddDays(-200), BusinessProfile.IT,
                    new Person("John", "Black"), 55, new Address("UK", "London", "10 Downing St")),

                new Firm("MarketPro", DateTime.Today.AddYears(-1).AddDays(-20), BusinessProfile.Marketing,
                    new Person("Sophia", "Brown"), 310, new Address("USA", "New York", "5th Ave")),

                new Firm("Global White Logistics", DateTime.Today.AddYears(-3), BusinessProfile.Logistics,
                    new Person("Oliver", "Black"), 95, new Address("UK", "Manchester", "King St")),

                new Firm("FinEdge", DateTime.Today.AddDays(-160), BusinessProfile.Finance,
                    new Person("Ava", "White"), 220, new Address("UK", "London", "Fleet St")),

                new Firm("Creato Marketing", DateTime.Today.AddYears(-7), BusinessProfile.Marketing,
                    new Person("Mason", "White"), 45, new Address("Germany", "Berlin", "Unter den Linden"))
            };

            IFirmRepository repo = new InMemoryFirmRepository(firms);
            IFirmQueryService service = new FirmQueryService(repo);

            ConsolePrinter.Print("All Firms", service.GetAll());
            ConsolePrinter.Print("Name Food", service.WithNameFood());
            ConsolePrinter.Print("Marketing", service.InMarketing());
            ConsolePrinter.Print("Marketing or IT", service.InMarketingOrIT());
            ConsolePrinter.Print("> 100 employers", service.WithEmployeesMoreThan100());
            ConsolePrinter.Print("100-300 employers", service.WithEmployeesBetween100And300());
            ConsolePrinter.Print("London", service.LocatedInLondon());
            ConsolePrinter.Print("Director White", service.DirectorLastNameWhite());
            ConsolePrinter.Print("> 2 Year ago", service.FoundedOverTwoYearsAgo());
            ConsolePrinter.Print("> 150 day ago", service.FoundedOver150DaysAgo());
            ConsolePrinter.Print("Director Black + name have White", service.DirectorBlackAndNameContainsWhite());

            Console.WriteLine("\nDone!");
            Console.ReadKey();
        }
    }
}