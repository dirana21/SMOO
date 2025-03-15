namespace Task1
{
    internal class Program
    {
        public static void Formula(int n)
        {
            int[]? array = (n switch
            {
                1 => FileInput.InputByFile(),
                2 => UserInput.InputByUser(),
                3 => RandomInput.InputByRandom(),
                _ => null
            })!;
            if (array == null)
            {
                Console.WriteLine("Wrong input, so no formula for you BROAH! MUHAHAHAHA");
                return;
            }
            PrintArray.ShowNotSortedArray(array);
            PrintArray.ShowSortedArray(MathOperation.Task(array));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option: 1 - input are takes by txt file, 2 - input by your self, 3 - input by random number");
            Formula(ChekerForInteger.CheckIfInt());
        }
    }
}