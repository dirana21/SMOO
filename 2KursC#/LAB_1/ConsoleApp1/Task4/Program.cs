using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionaryRepository repo = new FileDictionaryRepository();
            IWordExporter exporter = new WordExporter();
            IMenuRenderer menu = new ConsoleMenuRenderer(repo, exporter);

            menu.ShowMainMenu();
        }
    }
}