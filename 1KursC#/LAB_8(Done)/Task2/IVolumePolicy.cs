namespace Task2
{
    public interface IVolumePolicy
    { 
        bool CanAdd(List<ObjectInSuitcase> contents, ObjectInSuitcase newObj, double maxVolume);
    }
}