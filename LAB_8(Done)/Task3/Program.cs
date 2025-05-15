namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 7, 14, 21, 22, 35, 50, 70 };
            Console.WriteLine($"Multiples 7: {MultiplesOfSevenCounter.Count(numbers)}");
            Console.WriteLine($"Positive: {PositiveNumbersCounter.Count(numbers)}");

            DateTime testDate = new DateTime(2024, 9, 13);
            Console.WriteLine($"Is this Programmer's Day? {ProgrammersDayChecker.IsProgrammerDay(testDate)}");

            string text = "Hello! Today is a great day for programming.";
            string[] searchWords1 = { "Day", "Night" };
            string[] searchWords2 = { "Morning", "Evening" };

            Console.WriteLine($"Contains words from searchWords1? {TextContainsWordsChecker.ContainsAny(text, searchWords1)}");
            Console.WriteLine($"Contains words from searchWords2? {TextContainsWordsChecker.ContainsAny(text, searchWords2)}");
        }
    }
}