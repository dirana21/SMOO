namespace Task2
{
    public class FileTextReader : ITextReader
    {
        public string ReadText(string path) => File.ReadAllText(path);

        public List<string> ReadWords(string path) => File.ReadAllLines(path).ToList();
    }
}