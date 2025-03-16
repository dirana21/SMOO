namespace Task2
{
    public class ChekerForCorrectInput
    {
        public static double CheckIfDouble()
        {
            double chooseOne = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out chooseOne)) break;
                else Console.WriteLine("Wrong input, please try again");
            }
            return chooseOne;
        }
        public static int CheckIfInteger()
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
