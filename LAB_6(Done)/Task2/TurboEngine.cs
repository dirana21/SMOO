namespace Task2
{
    public class TurboEngine : InternalCombustionEngine
    {
        public TurboEngine() : base()
        {
            
        }

        public TurboEngine(double power, string manufacturer) : base(power, manufacturer, "Turbo")
        {
            
        }

        public override void Display()
        {
            Console.WriteLine($"\tTurbo engine\n Power: {Power} kW\n Manufacturer: {Manufacturer}");
        }
    }
}

