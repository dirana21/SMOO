namespace Task2
{
    public class Device : IDevice, ICloneable, IComparable<Device>
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public Device()
        {
            Name = "";
            Weight = 0;
        }

        public Device(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public int CompareTo(Device other)
        {
            if (other == null) return 1;
            return Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return $"\t{Name}\n Weight: {Weight} Kg";
        }

        public virtual object Clone()
        {
            return new Device(Name, Weight);
        }
    }
}