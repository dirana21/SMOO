namespace Task1
{
    public class UserInput
    {
        public static int[] InputByUser()
        {
            int[] array = new int[LenghtArray()];
            for (int i = 0; i < LenghtArray(); i++)
            {
                Console.WriteLine("Please enter a number: ");
                array[i] = ChekerForInteger.CheckIfInt();
            }
            return array;
        }
        public static int LenghtArray()
        {
            int lenght = 0;
            Console.WriteLine("Please enter how many number you want to enter to array: ");
            lenght = ChekerForInteger.CheckIfInt();
            return lenght;
        }
    }
}

