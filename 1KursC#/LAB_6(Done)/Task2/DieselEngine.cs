namespace Task2
{
    public class DieselEngine : InternalCombustionEngine
    {

        public DieselEngine(double power, string manufactutrer) : base(power, manufactutrer, "Diesel")
        {
            
        }
        public DieselEngine() : base()
        {
            
        }

        public override void Display()
        {
            Console.WriteLine($"\tDiesel Engine\n Power: {Power} kW\n Manufacturer: {Manufacturer}");
        }
    }
}

