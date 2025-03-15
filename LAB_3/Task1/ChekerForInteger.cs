namespace Task1
{
    public class ChekerForInteger
    {
        public static int CheckIfInt()
        {
            int chooseOne = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out chooseOne)) break;
                else Console.WriteLine("Wrong input, please try again");
            }
            return chooseOne;
        }
    }
}

