namespace FishModel
{
    public class Fish
    {
        public FishType Type { get; }
        public double Weight { get; }

        public Fish(FishType type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Type} by weight {Weight} KG";
        }
    }
}