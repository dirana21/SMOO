namespace Task1
{
    using System.Text.RegularExpressions;
    internal class Program
    {
        static void FirstTask()
        {
            /*
             1. Написати регулярний вираз, який визначає чи є заданий рядок рядком "abcdefghijklmnopqrstuv18340" чи ні.
                – правильний вираз: abcdefghijklmnopqrstuv18340.
                – невірний вираз:  abcdefghijklmnoasdfasdpqrstuv18340.
            */
            string pattern = @"^abcdefghijklmnopqrstuv18340$";
            string[] testStrings = {
                "abcdefghijklmnopqrstuv18340",
                "abcdefghijklmnoasdfasdpqrstuv18340",
                "abcdefghijklmnopqrstuv1834",
                "abcdefghijklmnopqrstuv18340xyz"
            };
            foreach (string test in testStrings)
            {
                Console.WriteLine($"Строка \"{test}\" " + (Regex.IsMatch(test, pattern) ? "Match" : "Not match") + " shablon.");
            }
        }
        static void SecondTask()
        {
            /*
             2. Написати регулярний вираз, який визначає чи є заданий рядок GUID з дужками або без дужок. GUID – це рядок, що складається з 8, 4, 4, 4, 12 шістнадцяткових цифр розділених тире.
                – правильний вираз: e02fd0e4-00fd-090A-ca30-0d00a0038ba0;
                – приклад неправильних виразів:e02fd0e400fd090Aca300d00a0038ba0.
            */
            string pattern = @"^\{?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\}?$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            string[] testCases = {
                "e02fd0e4-00fd-090A-ca30-0d00a0038ba0",
                "{e02fd0e4-00fd-090A-ca30-0d00a0038ba0}",
                "e02fd0e400fd090Aca300d00a0038ba0",
                "e02fd0e4-00fd-090A-ca30-0d00a0038ba0-",
                "{e02fd0e4-00fd-090A-ca30-0d00a0038ba0" 
            };

            foreach (var testCase in testCases)
            {
                Console.WriteLine($"{testCase} -> {regex.IsMatch(testCase)}");
            }
        }
        static void Main(string[] args)
        {
            FirstTask();
            SecondTask();
        }
    }
}

