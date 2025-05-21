using System.Text.RegularExpressions;
namespace Task2
{
    public class SimpleCensore : ICensor
    {
        public string Censor(string text, List<string> forbiddenWords)
        {
            foreach (var word in forbiddenWords)
            {
                string pattern = $@"\b{Regex.Escape(word)}\b";
                string replacement = new string('*', word.Length);
                text = Regex.Replace(text, pattern, replacement, RegexOptions.IgnoreCase);
            }
            return text;
        }
    }
}