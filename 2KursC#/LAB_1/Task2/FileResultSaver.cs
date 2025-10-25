using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task2
{
    public class FileResultSaver : IResultSaver
    {
        public void Save(Dictionary<string, int> wordStats, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            foreach (var pair in wordStats.OrderByDescending(p => p.Value))
            {
                writer.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}