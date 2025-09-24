namespace Task2
{
    public class SuitcaseLogger
    {
        public static void NotifyAdded(ObjectInSuitcase obj)
        {
            Console.WriteLine($"An object has been added to the suitcase.: {obj.Name}, volume: {obj.Volume}");
        }
    }
}