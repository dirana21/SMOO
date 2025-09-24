namespace Task2
{
    public class Balloon : Device
    {
        public bool HasEngine { get; set; }
        
        public Balloon() : base()
        {
            HasEngine = false;
        }

        public Balloon(string name, double weight) : base(name, weight)
        {
            HasEngine = false;
        }
        
        public override string ToString()
        {
            return base.ToString() + "\n No Engine";
        }
        
        public override object Clone()
        {
            return new Balloon(Name, Weight);
        }
    }
}