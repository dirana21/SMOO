using System.IO;
using System.Linq;

namespace Task4
{
    public class WordExporter : IWordExporter
    {
        public void ExportWord(LanguageDictionary dictionary, string word, string filePath)
        {
            var translations = dictionary.FindTranslations(word);
            if (!translations.Any()) return;

            using var writer = new StreamWriter(filePath);
            writer.WriteLine($"{word} -> {string.Join(", ", translations)}");
        }
    }
}