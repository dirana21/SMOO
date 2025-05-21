namespace Task2
{
    public interface ITextReader
    {
        string ReadText(string path);
        List<string> ReadWords(string path);
    }
}