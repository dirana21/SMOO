namespace Task2
{

    public class InternalCombustionEngine : Engine
    {
        public string Type { get; set; }

        public InternalCombustionEngine(double power, string manufacturer, string type) : base(manufacturer, power)
        {
            Type = type;
        }

        public InternalCombustionEngine() : base()
        {
            Type = "Unknown";
        }

        public override void Display()
        {
            Console.WriteLine($"\tInternal Combustion Engine\n Power {Power} kW \n Manufacturer: {Manufacturer}\n Type: {Type}");
        }
    }
}