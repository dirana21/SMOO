namespace FishModel
{
    public class RandomProvider : IRandomProvider
    {
        private Random _random = new Random();

        public double NextDouble() => _random.NextDouble();
        public int Next(int min, int max) => _random.Next(min, max);
    }
}