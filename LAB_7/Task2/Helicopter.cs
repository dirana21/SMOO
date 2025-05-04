namespace Task2
{
    public class Helicopter : Device, IEngine
    {
        public double EnginePower { get; set; }
        public bool HasEngine { get; set; }
        
        public Helicopter() : base()
        {
            EnginePower = 0;
            HasEngine = false;
        }

        public Helicopter(string name, double weight, double enginePower) : base(name, weight)
        {
            EnginePower = enginePower;
            HasEngine = true;
        }
        
        public override string ToString()
        {
            return base.ToString() + $"\n Engine Power: {EnginePower} HP";
        }

        public override object Clone()
        {
            return new Helicopter(Name, Weight, EnginePower);
        }
    }
}