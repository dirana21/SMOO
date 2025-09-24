using System;

namespace Task4
{
    public class ConsoleMenuRenderer : IMenuRenderer
    {
        private readonly IDictionaryRepository _repo;
        private readonly IWordExporter _exporter;

        public ConsoleMenuRenderer(IDictionaryRepository repo, IWordExporter exporter)
        {
            _repo = repo;
            _exporter = exporter;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Dictionaries ===");
                Console.WriteLine("1. List of dictionaries");
                Console.WriteLine("2. Create a dictionary");
                Console.WriteLine("3. Delete dictionary");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        foreach (var d in _repo.GetAllDictionaries())
                            Console.WriteLine($"- {d.Name} ({d.Type})");

                        Console.Write("Enter the name of the dictionary to open: ");
                        var name = Console.ReadLine();
                        var dict = _repo.GetDictionary(name);
                        if (dict != null) ShowDictionaryMenu(dict);
                        break;

                    case "2":
                        Console.Write("The name of the dictionary: ");
                        var dictName = Console.ReadLine();
                        var newDict = new LanguageDictionary { Name = dictName, Type = DictionaryType.Custom };
                        _repo.SaveDictionary(newDict);
                        break;

                    case "3":
                        Console.Write("Name of the dictionary to delete: ");
                        _repo.DeleteDictionary(Console.ReadLine());
                        break;

                    case "0":
                        return;
                }
            }
        }

        public void ShowDictionaryMenu(LanguageDictionary dictionary)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== {dictionary.Name} ===");
                Console.WriteLine("1. Add a word");
                Console.WriteLine("2. Replace the word");
                Console.WriteLine("3. Replace the translation");
                Console.WriteLine("4. Delete the word");
                Console.WriteLine("5. Remove translation");
                Console.WriteLine("6. Translation search");
                Console.WriteLine("7. Export word to file");
                Console.WriteLine("0. Back");
                Console.Write("Your choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Word: ");
                        string word = Console.ReadLine();
                        Console.Write("Translate: ");
                        string tr = Console.ReadLine();
                        dictionary.AddWord(word, tr);
                        _repo.SaveDictionary(dictionary);
                        break;

                    case "2":
                        Console.Write("Old word: ");
                        string oldWord = Console.ReadLine();
                        Console.Write("New word: ");
                        string newWord = Console.ReadLine();
                        dictionary.ReplaceWord(oldWord, newWord);
                        _repo.SaveDictionary(dictionary);
                        break;

                    case "3":
                        Console.Write("Word: ");
                        string w1 = Console.ReadLine();
                        Console.Write("Old translation: ");
                        string oldTr = Console.ReadLine();
                        Console.Write("New translation: ");
                        string newTr = Console.ReadLine();
                        dictionary.ReplaceTranslation(w1, oldTr, newTr);
                        _repo.SaveDictionary(dictionary);
                        break;

                    case "4":
                        Console.Write("Word to delete: ");
                        dictionary.RemoveWord(Console.ReadLine());
                        _repo.SaveDictionary(dictionary);
                        break;

                    case "5":
                        Console.Write("Word: ");
                        string w2 = Console.ReadLine();
                        Console.Write("Translation to delete: ");
                        string trDel = Console.ReadLine();
                        dictionary.RemoveTranslation(w2, trDel);
                        _repo.SaveDictionary(dictionary);
                        break;

                    case "6":
                        Console.Write("Search word: ");
                        var translations = dictionary.FindTranslations(Console.ReadLine());
                        Console.WriteLine($"Translations: {string.Join(", ", translations)}");
                        Console.ReadKey();
                        break;

                    case "7":
                        Console.Write("A word for export: ");
                        string w3 = Console.ReadLine();
                        _exporter.ExportWord(dictionary, w3, $"{w3}_export.txt");
                        Console.WriteLine("Export completed!");
                        Console.ReadKey();
                        break;

                    case "0":
                        return;
                }
            }
        }
    }
}