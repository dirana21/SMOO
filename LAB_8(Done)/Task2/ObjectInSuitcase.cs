namespace Task2
{
    public class ObjectInSuitcase
    {
        private string name;
        private double volume;
        public string Name { get => name; set => name = value; }
        public double Volume { get => volume; set => volume = value; }
        
        public ObjectInSuitcase()
        {
            Name = "";
            Volume = 0.0;
        }

        public ObjectInSuitcase(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }
    }
}