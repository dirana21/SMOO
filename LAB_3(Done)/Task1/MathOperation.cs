namespace Task1
{
    public class MathOperation
    {
        public static int[] Task(int[] array)
        {
            int[] result = new int[array.Length];
            int counterPlusNumber = 0;
            int lastMinusIndex = 0;
            int thirdPositiveIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
                if (array[i] > 0)
                {
                    counterPlusNumber++;
                    if (counterPlusNumber == 3) thirdPositiveIndex = i;
                }
                if (array[i] < 0) lastMinusIndex = i;
            }
            int start = Math.Min(thirdPositiveIndex, lastMinusIndex) + 1;
            int end = Math.Max(thirdPositiveIndex, lastMinusIndex) - 1;
            for (int i = start; i <= end; i++)
            {
                result[i] = -array[i];
            }
            return result;
        }
    }
}

