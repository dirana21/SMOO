namespace Task2
{
    public class Airplane : Device, IEngine
    {
        public double EnginePower { get; set; }
        public bool HasEngine { get; set; }

        public Airplane() : base()
        {
            EnginePower = 0;
            HasEngine = false;
        }

        public Airplane(string name, double weight, double enginePower) : base(name, weight)
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
            return new Airplane(Name, Weight, EnginePower);
        }
    }
}