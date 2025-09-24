using System.Collections.Generic;

namespace Task4
{
    public class TranslationEntry
    {
        public string Word { get; set; }
        public List<string> Translations { get; set; } = new List<string>();

        public override string ToString() => $"{Word} -> {string.Join(", ", Translations)}";
    }
}