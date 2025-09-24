namespace FishModel
{
    public interface IRandomProvider
    {
        double NextDouble();
        int Next(int min, int max);
    }
}