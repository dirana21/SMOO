using System.Collections.Generic;

namespace Task4
{
    public interface IDictionaryRepository
    {
        IEnumerable<LanguageDictionary> GetAllDictionaries();
        LanguageDictionary GetDictionary(string name);
        void SaveDictionary(LanguageDictionary dictionary);
        void DeleteDictionary(string name);
    }
}