using System.Text.RegularExpressions;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            Console.WriteLine("\t--Несортированый текст--");
            foreach (string i in lines)
            {
                Console.WriteLine($"{i}");
            }
            string pattern = @"[\s.,!?;:]+";
            Console.WriteLine("\t--Сортированый текст--");
            foreach (string value in lines)
            {
                string[] words = Regex.Split(value, pattern);
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < words[i].Length - 1; j++)
                    {
                        char firstChar = char.ToLower(words[i][0]);
                        char secondChar = char.ToLower(words[i][j + 1]);
                        if (firstChar == secondChar)
                        {
                            Console.WriteLine($"В этом слове мы нашли еще одну одинаковую букву: {words[i]}");
                            break;
                        }
                    }
                }
            }
        }
    }
}

