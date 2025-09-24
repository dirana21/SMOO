namespace Task2
{
    public class MathOperation
    {
        public static double[][] Task(double[][] array)
        {
            int line = array.Length;
            for (int i = 0; i < line; i++)
            {
                if (array[i].Length == 0) continue;
                int maxIndex = 0;
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j] > array[i][maxIndex])maxIndex = j;
                }
                double diagonalElement = (i < array[i].Length) ? array[i][i] : array[i][array[i].Length - 1];
                array[i][maxIndex] = Math.Abs(diagonalElement);
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < 0)array[i][j] = Math.Pow(array[i][j], 3);
                }
                Array.Sort(array[i]);
            }
            return array;
        }
    }
}

