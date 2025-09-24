namespace Task3
{
    public class PositiveNumbersCounter
    {
        public static Func<int[], int> Count = array => array.Count(x => x > 0);
    }
}