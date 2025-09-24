namespace Task2
{
    public interface ICensor
    {
        string Censor(string text, List<string> forbiddenWords);
    }
}