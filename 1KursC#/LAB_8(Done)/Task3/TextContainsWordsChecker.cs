namespace Task3
{
    public class TextContainsWordsChecker
    {   
        public static Func<string, string[], bool> ContainsAny = (text, words) =>
        {
            foreach (var word in words)
            {
                if (text.ToLower().Contains(word.ToLower()))
                    return true;
            }
            return false;
        };
    }
}