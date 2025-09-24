namespace FishModel
{
    public class Fisher
    {
        public string Name { get; }
        public double TotalCatchWeight { get; private set; }

        public Fisher(string name)
        {
            Name = name;
            TotalCatchWeight = 0;
        }

        public void AddCatch(double weight)
        {
            TotalCatchWeight += weight;
        }
    }
}