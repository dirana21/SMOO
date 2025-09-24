namespace Task1
{
    public class LetterCounter : ILetterCounter
    {
        private static readonly char[] vowels = { 'а', 'е', 'є', 'и', 'і', 'ї', 'о', 'у', 'ю', 'я' };
        public int CountUppercase(string text) => text.Count(c => char.IsUpper(c));
        public int CountLowercase(string text) => text.Count(c => char.IsLower(c));
        public int CountVowels(string text) => text.ToLower().Count(c => vowels.Contains(c));
        public int CountConsonants(string text) => text.ToLower().Count(c => char.IsLetter(c) && !vowels.Contains(c));
    }   
}