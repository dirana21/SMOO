namespace Task1
{
    public class TextStatistics
    {
        public int SentenceCount { get; set; }
        public int UppercaseCount { get; set; }
        public int LowercaseCount { get; set; }
        public int VowelCount { get; set; }
        public int ConsonantCount { get; set; }
        public int DigitCount { get; set; }

        public void Print()
        {
            Console.WriteLine("File statistics:");
            Console.WriteLine($"- Number of sentences: {SentenceCount}");
            Console.WriteLine($"- Capital letters: {UppercaseCount}");
            Console.WriteLine($"- Lowercase letters: {LowercaseCount}");
            Console.WriteLine($"- Vowels letters: {VowelCount}");
            Console.WriteLine($"- Consonant letters: {ConsonantCount}");
            Console.WriteLine($"- Number: {DigitCount}");
        }
    }
}