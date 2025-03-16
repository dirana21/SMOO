namespace Task1
{
    public class RandomInput
    {
        public static int[] InputByRandom()
        {
            Random random = new Random();
            int lenght = random.Next(10, 15);
            int[] array = new int[lenght];
            for (int i = 0; i < lenght; i++)
            {
                array[i] = random.Next(-100, 100);
            }
            return array;
        }
    }
}

