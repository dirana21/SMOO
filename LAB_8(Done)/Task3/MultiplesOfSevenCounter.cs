namespace Task3
{
    public class MultiplesOfSevenCounter
    {
        public static int Count(int[] numbers)
        {
            return numbers.Count(x => x % 7 == 0);
        }
    }
}