namespace Task1
{
    public class PrintArray
    {
        public static void ShowSortedArray(int[] array)
        {
            Console.WriteLine("This is sorted array by the task of 3+ number for last -number");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"index {i} = {array[i]}");
            }
        }
        public static void ShowNotSortedArray(int[] array)
        {
            Console.WriteLine("This is not sorted array.");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"index {i} = {array[i]}");
            }
        }
    }
}

