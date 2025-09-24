using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class WordCounter : IWordCounter
    {
        public Dictionary<string, int> CountWords(string text)
        {
            var words = text
                .ToLower()
                .Split(new[] { ' ', '\n', '\r', '\t', ',', '.', '!', '?', ';', ':', '-', '\"' },
                    StringSplitOptions.RemoveEmptyEntries);

            return words
                .GroupBy(w => w)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}