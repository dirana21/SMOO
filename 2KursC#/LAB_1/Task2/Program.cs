using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IFileProvider fileProvider = new FileListProvider("firstFile.txt");
                ITextReader textReader = new SimpleTextReader();
                IWordCounter wordCounter = new WordCounter();
                IResultPrinter printer = new ConsoleResultPrinter();
                IResultSaver saver = new FileResultSaver();

                var availableFiles = fileProvider.GetAvailableFiles().ToList();
                Console.WriteLine("Available files for analysis:");
                for (int i = 0; i < availableFiles.Count; i++)
                    Console.WriteLine($"{i + 1}. {availableFiles[i]}");

                Console.Write("\nChoose number of file: ");
                int choice = int.Parse(Console.ReadLine() ?? "1");
                string selectedFile = availableFiles[choice - 1];

                string text = textReader.ReadText(selectedFile);
                var wordStats = wordCounter.CountWords(text);

                printer.Print(wordStats);

                Console.Write("\nSave the result to a file? (y/n): ");
                if (Console.ReadLine()?.Trim().ToLower() == "y")
                {
                    string resultFile = "word_stats.txt";
                    saver.Save(wordStats, resultFile);
                    Console.WriteLine($"The result is saved in {resultFile}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}