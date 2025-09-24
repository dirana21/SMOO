namespace FishModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new RandomProvider();
            var fishingEvent = new FishingEvent(random);

            var brother1 = new Fisher("Andrey");
            var brother2 = new Fisher("Bogdan");

            var simulator = new FishingSimulator(brother1, brother2, random, fishingEvent,6);
            simulator.StartFishing();
        }
    }
}