using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public class LanguageDictionary
    {
        public string Name { get; set; }
        public DictionaryType Type { get; set; }
        public List<TranslationEntry> Entries { get; set; } = new List<TranslationEntry>();

        public void AddWord(string word, string translation)
        {
            var entry = Entries.FirstOrDefault(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
            if (entry == null)
            {
                entry = new TranslationEntry { Word = word };
                Entries.Add(entry);
            }
            entry.Translations.Add(translation);
        }

        public void ReplaceWord(string oldWord, string newWord)
        {
            var entry = Entries.FirstOrDefault(e => e.Word.Equals(oldWord, StringComparison.OrdinalIgnoreCase));
            if (entry != null)
            {
                entry.Word = newWord;
            }
        }

        public void ReplaceTranslation(string word, string oldTranslation, string newTranslation)
        {
            var entry = Entries.FirstOrDefault(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
            if (entry != null)
            {
                int index = entry.Translations.FindIndex(t => t.Equals(oldTranslation, StringComparison.OrdinalIgnoreCase));
                if (index >= 0)
                {
                    entry.Translations[index] = newTranslation;
                }
            }
        }

        public void RemoveWord(string word)
        {
            Entries.RemoveAll(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveTranslation(string word, string translation)
        {
            var entry = Entries.FirstOrDefault(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
            if (entry != null && entry.Translations.Count > 1)
            {
                entry.Translations.RemoveAll(t => t.Equals(translation, StringComparison.OrdinalIgnoreCase));
            }
        }

        public IEnumerable<string> FindTranslations(string word)
        {
            var entry = Entries.FirstOrDefault(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
            return entry?.Translations ?? Enumerable.Empty<string>();
        }
    }
}