namespace Task2
{
    public sealed class ManufacturerCount
    {
        public string Manufacturer { get; set; } = "";
        public int Count { get; set; }
        public override string ToString() => $"{Manufacturer} – {Count}";
    }
}