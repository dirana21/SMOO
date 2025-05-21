namespace Task1
{
    public class TextAnalyzer
    {
        private readonly ISentenceCounter sentenceCounter;
        private readonly ILetterCounter letterCounter;
        private readonly IDigitCounter digitCounter;

        public TextAnalyzer(ISentenceCounter sc, ILetterCounter lc, IDigitCounter dc)
        {
            sentenceCounter = sc;
            letterCounter = lc;
            digitCounter = dc;
        }

        public TextStatistics Analyze(string text)
        {
            return new TextStatistics
            {
                SentenceCount = sentenceCounter.CountSentences(text),
                UppercaseCount = letterCounter.CountUppercase(text),
                LowercaseCount = letterCounter.CountLowercase(text),
                VowelCount = letterCounter.CountVowels(text),
                ConsonantCount = letterCounter.CountConsonants(text),
                DigitCount = digitCounter.CountDigits(text)
            };
        }
    }
}