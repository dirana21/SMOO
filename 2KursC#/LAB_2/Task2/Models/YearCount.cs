namespace Task2
{
    public sealed class YearCount
    {
        public int Year { get; set; }
        public int Count { get; set; }
        public override string ToString() => $"{Year} – {Count}";
    }
}