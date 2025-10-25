namespace Task4
{
    public interface IWordExporter
    {
        void ExportWord(LanguageDictionary dictionary, string word, string filePath);
    }
}