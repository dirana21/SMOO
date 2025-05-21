namespace Task1
{
    public class SentenceCounter : ISentenceCounter
    {
        public int CountSentences(string text) => text.Count(c => c == '.' || c == '!' || c == '?');
    }
}