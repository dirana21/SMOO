namespace Task2
{
    public class HangGlider : Device
    {
        public bool HasEngine { get; set; }
        
        public HangGlider() : base()
        {
            HasEngine = false;
        }

        public HangGlider(string name, double weight) : base(name, weight)
        {
            HasEngine = false;
        }
        
        public override string ToString()
        {
            return base.ToString() + "\n No Engine";
        }
        
        public override object Clone()
        {
            return new HangGlider(Name, Weight);
        }
    }
}