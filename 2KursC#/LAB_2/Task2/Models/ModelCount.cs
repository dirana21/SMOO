namespace Task2
{
    public sealed class ModelCount
    {
        public string Model { get; set; } = "";
        public int Count { get; set; }
        public override string ToString() => $"{Model} – {Count}";
    }
}