namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input path to file: ");
            string? path  = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }
            
            string text = File.ReadAllText(path);
            
            var analyzer = new TextAnalyzer(
                new SentenceCounter(),
                new LetterCounter(),
                new DigitCounter()
            );

            var stats = analyzer.Analyze(text);
            stats.Print();

            Console.ReadLine();
        }
    }
}