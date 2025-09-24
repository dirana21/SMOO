using System.IO;

namespace Task2
{
    public class SimpleTextReader : ITextReader
    {
        public string ReadText(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File {filePath} not found.");
            return File.ReadAllText(filePath);
        }
    }
}