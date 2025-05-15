namespace Task2
{
    public class StrictVolumePolicy : IVolumePolicy
    {
        public bool CanAdd(List<ObjectInSuitcase> contents, ObjectInSuitcase newObj, double maxVolume)
        {
            double total = 0;
            foreach (var item in contents) total += item.Volume;
            return total + newObj.Volume <= maxVolume;
        }
    }
}