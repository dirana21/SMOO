namespace Task3
{
    public class PositiveNumbersCounter
    {
        public static int Count(int[] numbers)
        {
            return numbers.Count(x => x > 0);
        }
    }
}