namespace Task2
{
    public abstract class Engine
    {
        public double Power { get; set; }
        public string Manufacturer { get; set; }

        public Engine(string manufacturer, double power)
        {
            if (power < 0)
            {
                throw new ArgumentException("Power cannot be negative.");
            }
            Manufacturer = manufacturer;
            Power = power;
        }

        public Engine()
        {
            Power = 0;
            Manufacturer = "Undefined";
        }
        
        public abstract void Display();
    }
}