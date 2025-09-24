namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine[] engines = new Engine[]
            {
                new DieselEngine(560,"Company A"),
                new DieselEngine(850,"Company B"),
                new TurboEngine(1500,"Company C"),
                new TurboEngine(2500,"Company D"),
                new InternalCombustionEngine(1000, "Company E", "Benzine/Petrol"),
                new TurboEngine()
            };
            
            ShowEngines.Show(engines);
            CalculateAvaragePowerOfEngines.CalculateDiesel(engines);
            CalculateAvaragePowerOfEngines.CalculateTubo(engines);
            CalculateAvaragePowerOfEngines.CalculateInternalCombustion(engines);
        }
    }
}

