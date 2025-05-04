namespace Task2
{
    public class FlyingCarpet : Device
    {
        public bool HasEngine { get; set; }
        
        public FlyingCarpet() : base()
        {
            HasEngine = false;
        }

        public FlyingCarpet(string name, double weight) : base(name, weight)
        {
            HasEngine = false;
        }
        
        public override string ToString()
        {
            return base.ToString() + "\n No Engine";
        }
        
        public override object Clone()
        {
            return new FlyingCarpet(Name, Weight);
        }
    }
}