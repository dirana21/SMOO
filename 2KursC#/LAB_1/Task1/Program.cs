using System;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            IZayavkaRepository repository = new JsonZayavkaRepository("zayavky.json");
            ZayavkaService service = new ZayavkaService(repository);

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Show all data");
                Console.WriteLine("2. Add new data");
                Console.WriteLine("3. Delete data");
                Console.WriteLine("4. Edit data");
                Console.WriteLine("5. Request for data and flight number");
                Console.WriteLine("0. Exit");
                Console.Write("choice: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        service.PrintAll();
                        break;

                    case "2":
                        Console.Write("Destination: ");
                        string punkt = Console.ReadLine();

                        Console.Write("flight number: ");
                        string reys = Console.ReadLine();

                        Console.Write("Passenger's full name: ");
                        string pib = Console.ReadLine();

                        Console.Write("Departure date (yyyy-mm-dd): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());

                        service.Add(new ZayavkaNaAviabilet
                        {
                            PunktPriznachennya = punkt,
                            NomerReysu = reys,
                            PIBPasazhira = pib,
                            DataVylotu = date
                        });
                        break;

                    case "3":
                        service.PrintAll();
                        Console.Write("Enter the index to delete.: ");
                        int indexDel = int.Parse(Console.ReadLine());
                        service.Remove(indexDel);
                        break;

                    case "4":
                        service.PrintAll();
                        Console.Write("Enter the index to edit.: ");
                        int indexEdit = int.Parse(Console.ReadLine());

                        Console.Write("New Destination: ");
                        string newPunkt = Console.ReadLine();

                        Console.Write("Flight number: ");
                        string newReys = Console.ReadLine();

                        Console.Write("New Passenger's full name: ");
                        string newPib = Console.ReadLine();

                        Console.Write("New Departure date (yyyy-mm-dd): ");
                        DateTime newDate = DateTime.Parse(Console.ReadLine());

                        service.Edit(indexEdit, new ZayavkaNaAviabilet
                        {
                            PunktPriznachennya = newPunkt,
                            NomerReysu = newReys,
                            PIBPasazhira = newPib,
                            DataVylotu = newDate
                        });
                        break;

                    case "5":
                        Console.Write("Enter flight number: ");
                        string queryReys = Console.ReadLine();

                        Console.Write("Start date (yyyy-mm-dd): ");
                        DateTime start = DateTime.Parse(Console.ReadLine());

                        Console.Write("End date (yyyy-mm-dd): ");
                        DateTime end = DateTime.Parse(Console.ReadLine());

                        var result = service.Query(queryReys, start, end);

                        Console.WriteLine("\nQuery result:");
                        foreach (var z in result)
                        {
                            Console.WriteLine(z);
                        }

                        service.PrintToFile(result, "result.txt");
                        Console.WriteLine("The result is recorded in result.txt");
                        break;
                }
            }
        }
    }
}