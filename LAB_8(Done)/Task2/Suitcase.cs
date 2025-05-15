namespace Task2
{
    
    public class Suitcase
    {
        public delegate void ObjectAddedHandler(ObjectInSuitcase obj);
        public event ObjectAddedHandler OnObjectAdded;
        private string color;
        public string Color { get => color; set => color = value; }
        private string brand;
        public string Brand { get => brand; set => brand = value; }
        private double weight;
        public double Weight { get => weight; set => weight = value; }
        private double volume;
        public double Volume { get => volume; set => volume = value; }
        private List<ObjectInSuitcase> contents;
        public List<ObjectInSuitcase> Contents { get => contents; set => contents = value; }
        private IVolumePolicy volumePolicy;
        public IVolumePolicy VolumePolicy { get => volumePolicy; set => volumePolicy = value; }

        public Suitcase()
        {
            Contents = new List<ObjectInSuitcase>();
            Color = "red";
            Brand = "D&G";
            Weight = 1.0;
            Volume = 1.0;
        }

        public Suitcase(string color, string brand, double weight, double volume, List<ObjectInSuitcase> contents, IVolumePolicy volumePolicy)
        {
            Color = color;
            Brand = brand;
            Weight = weight;
            Volume = volume;
            Contents = contents ?? new List<ObjectInSuitcase>();
            VolumePolicy = volumePolicy;
        }
        
        public void AddObject(ObjectInSuitcase obj)
        {
            if (volumePolicy.CanAdd(Contents, obj, Volume))
            {
                Contents.Add(obj);
                OnObjectAdded?.Invoke(obj);
            }
            else throw new InvalidOperationException("The suitcase capacity will be exceeded!");
        }
    }
}