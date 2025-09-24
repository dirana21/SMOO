namespace Task1
{
    public interface ILetterCounter
    {
        int CountUppercase(string text);
        int CountLowercase(string text);
        int CountVowels(string text);
        int CountConsonants(string text);
    }
}