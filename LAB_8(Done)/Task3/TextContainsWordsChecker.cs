namespace Task3
{
    public class TextContainsWordsChecker
    {   
        public static bool ContainsAny(string text, string[] words)
        {
            string loweredText = text.ToLower();
            foreach (string word in words)
            {
                string loweredWord = word.ToLower();
                if (loweredText.Contains(loweredWord)) return true;
            }
            return false;
        }
    }
}