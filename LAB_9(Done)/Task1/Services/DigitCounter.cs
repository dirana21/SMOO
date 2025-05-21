namespace Task1
{
    public class DigitCounter : IDigitCounter
    {
        public int CountDigits(string text) => text.Count(c => char.IsDigit(c));
    }
}