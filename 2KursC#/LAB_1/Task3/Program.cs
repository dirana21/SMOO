using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrintQueue queue = new PriorityPrintQueue();
            IPrintLogger logger = new PrintLogger();
            IResultPrinter printer = new ConsoleResultPrinter();
            IResultSaver saver = new FileResultSaver();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a print job");
                Console.WriteLine("2. Process next job");
                Console.WriteLine("3. Show statistics");
                Console.WriteLine("4. Save statistics to a file");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Username: ");
                        string user = Console.ReadLine();

                        Console.Write("Document name: ");
                        string doc = Console.ReadLine();

                        Console.Write("Priority (Low, Normal, High): ");
                        Enum.TryParse(Console.ReadLine(), true, out PrintPriority priority);

                        queue.AddJob(new PrintJob(user, doc, priority));
                        Console.WriteLine("Task added!");
                        break;

                    case "2":
                        if (!queue.HasJobs())
                        {
                            Console.WriteLine("The queue is empty.");
                        }
                        else
                        {
                            var job = queue.GetNextJob();
                            Console.WriteLine($"Print: {job}");
                            logger.Log(job);
                        }
                        break;

                    case "3":
                        printer.Print(logger.GetLogs());
                        break;

                    case "4":
                        saver.Save(logger.GetLogs(), "print_log.txt");
                        Console.WriteLine("Statistics saved in print_log.txt");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }
            }
        }
    }
}