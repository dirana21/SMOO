using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task4
{
    public class FileDictionaryRepository : IDictionaryRepository
    {
        private readonly string _storagePath;

        public FileDictionaryRepository(string storagePath = "Dictionaries")
        {
            _storagePath = storagePath;
            if (!Directory.Exists(_storagePath))
                Directory.CreateDirectory(_storagePath);
        }

        public IEnumerable<LanguageDictionary> GetAllDictionaries()
        {
            foreach (var file in Directory.GetFiles(_storagePath, "*.json"))
            {
                yield return JsonSerializer.Deserialize<LanguageDictionary>(File.ReadAllText(file));
            }
        }

        public LanguageDictionary GetDictionary(string name)
        {
            var path = Path.Combine(_storagePath, $"{name}.json");
            if (!File.Exists(path)) return null;
            return JsonSerializer.Deserialize<LanguageDictionary>(File.ReadAllText(path));
        }

        public void SaveDictionary(LanguageDictionary dictionary)
        {
            var path = Path.Combine(_storagePath, $"{dictionary.Name}.json");
            File.WriteAllText(path, JsonSerializer.Serialize(dictionary, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void DeleteDictionary(string name)
        {
            var path = Path.Combine(_storagePath, $"{name}.json");
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}