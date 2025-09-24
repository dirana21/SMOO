namespace Task3
{
    public class MultiplesOfSevenCounter
    {
        public static Func<int[], int> Count = array => array.Count(x => x % 7 == 0);
    }
}