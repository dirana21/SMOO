namespace FishModel
{
    public class FishingEvent : IFishingEvent
    {
        private readonly IRandomProvider _random;
        private const double BiteEscapeChance = 0.2;
        private const double NoBaitChance = 0.1;

        public FishingEvent(IRandomProvider random)
        {
            _random = random;
        }

        public string TryCatchFish(Fisher fisher)
        {
            if (_random.NextDouble() < NoBaitChance)
                return $"{fisher.Name} couldn't catch - ran out of bait.";

            if (_random.NextDouble() < BiteEscapeChance)
                return $"{fisher.Name} was pulling the fish, but it broke..";

            Fish caughtFish = GetRandomFish();
            fisher.AddCatch(caughtFish.Weight);
            return $"{fisher.Name} caught {caughtFish}";
        }

        private Fish GetRandomFish()
        {
            double roll = _random.NextDouble();

            if (roll < 0.4)
                return new Fish(FishType.Crucian, Math.Round(0.3 + _random.NextDouble() * 0.7, 2));
            else if (roll < 0.7)
                return new Fish(FishType.Pike, Math.Round(0.5 + _random.NextDouble() * 1.0, 2));
            else if (roll < 0.9)
                return new Fish(FishType.Catfish, Math.Round(1.0 + _random.NextDouble() * 2.0, 2));
            else
                return new Fish(FishType.Perch, Math.Round(2.0 + _random.NextDouble() * 3.0, 2));
        }
    }
}