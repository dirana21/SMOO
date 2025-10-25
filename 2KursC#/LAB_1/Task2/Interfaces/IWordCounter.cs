using System.Collections.Generic;

namespace Task2
{
    public interface IWordCounter
    {
        Dictionary<string, int> CountWords(string text);
    }
}