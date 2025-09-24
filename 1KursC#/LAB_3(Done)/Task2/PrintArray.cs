namespace Task2
{
    public class PrintArray
    {
        public static void PrintDoubleArray(double[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine(); 
            }
        }
    }
}

