namespace Task2
{
    internal class Program
    {
        public delegate void ObjectAddedHandler(ObjectInSuitcase obj);
        static void Main(string[] args)
        {
            var volumePolicy = new StrictVolumePolicy();
            Suitcase mySuitcase = new Suitcase("Black", "Samsonite", 3.5, 10.0, new List<ObjectInSuitcase>(), volumePolicy);
            mySuitcase.OnObjectAdded += SuitcaseLogger.NotifyAdded;
            
            try
            {
                mySuitcase.AddObject(new ObjectInSuitcase("Notebook", 3.0));
                mySuitcase.AddObject(new ObjectInSuitcase("Book", 2.0));
                mySuitcase.AddObject(new ObjectInSuitcase("Sneakers", 4.0));
                mySuitcase.AddObject(new ObjectInSuitcase("Hair dryer", 1.0));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadLine();
        }
        
    }
}

