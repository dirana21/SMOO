namespace Task1
{
    public class Data
    {
        public static void DataTime()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }

        public static void Date()
        {
            Console.WriteLine(DateTime.Now.ToLongDateString());
        }

        public static void DataWeek()
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
        }
    }
}