namespace Task2
{
    public class CensoreManager
    {
        private readonly ITextReader _reader;
        private readonly ITextWriter _writer;
        private readonly ICensor _censorship;

        public CensoreManager(ITextReader reader, ITextWriter writer, ICensor censorship)
        {
            _reader = reader;
            _writer = writer;
            _censorship = censorship;
        }

        public void Run(string textPath, string forbiddenWordsPath, string outputPath)
        {
            var text = _reader.ReadText(textPath);
            var forbiddenWords = _reader.ReadWords(forbiddenWordsPath);
            var censoredText = _censorship.Censor(text, forbiddenWords);
            _writer.WriteText(outputPath, censoredText);
        }
    }
}