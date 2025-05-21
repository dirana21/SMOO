namespace Task2
{
    public class FileTextWriter : ITextWriter
    {
        public void WriteText(string path, string content) => File.WriteAllText(path, content);
    }
}