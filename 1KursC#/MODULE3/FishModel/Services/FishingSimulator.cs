namespace FishModel
{
    public class FishingSimulator
    {
        private readonly IRandomProvider _random;
        private readonly IFishingEvent _fishingEvent;
        private readonly Fisher _fisher1;
        private readonly Fisher _fisher2;
        private readonly int _totalAttempts;

        public FishingSimulator(Fisher fisher1, Fisher fisher2, IRandomProvider random, IFishingEvent fishingEvent,int hours)
        {
            _fisher1 = fisher1;
            _fisher2 = fisher2;
            _random = random;
            _fishingEvent = fishingEvent;
            _totalAttempts = (hours * 60) / 15;
        }

        public void StartFishing()
        {
            for (int i = 1; i <= _totalAttempts; i++)
            {
                Fisher selectedFisher = _random.Next(0, 2) == 0 ? _fisher1 : _fisher2;
                string result = _fishingEvent.TryCatchFish(selectedFisher);
                Console.WriteLine($"[{i}] {result}");
            }

            Console.WriteLine("\n=== Fisherman's summary ===");
            Console.WriteLine($"{_fisher1.Name} caught {_fisher1.TotalCatchWeight} KG.");
            Console.WriteLine($"{_fisher2.Name} caught {_fisher2.TotalCatchWeight} KG.");
        }
    }
}