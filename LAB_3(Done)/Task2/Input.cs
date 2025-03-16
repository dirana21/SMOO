namespace Task2;

public class Input
{
    public static double[][] InputByRandom()
    {
        Random random = new Random();
        int lenghtrow = random.Next(1, 7);
    
        double[][] array = new double[lenghtrow][];
    
        for (int i = 0; i < lenghtrow; i++)
        {
            int lenghtcol = random.Next(1, 7);
            array[i] = new double[lenghtcol];

            for (int j = 0; j < lenghtcol; j++)
            {
                double num = Math.Round(Math.Sin((i + 1) + (j + 1)) * (random.NextDouble() * 200 - 100), 2);
                array[i][j] = num;
            }
        }

        return array;
    }
    
    public static double[][] InputByUser()
    {
        double[][] array = new double[LenghtArrayLines()][];
        for (int i = 0; i < LenghtArrayLines(); i++)
        {
            List<double> row = new List<double>();
            Console.WriteLine("Just write to an console any string when u want to stop fill line by number");
            Console.WriteLine("So, u can start type any number to add to array line");
            Console.WriteLine($"Line #{i + 1}");
            while (true)
            {
                string input = Console.ReadLine() ?? "";
                double num = 0;
                if (double.TryParse(input, out num))  row.Add(num);
                else break;
            }
            array[i] = row.ToArray();
        }
        return array;
    }
    private static int LenghtArrayLines()
    {
        Console.WriteLine("Choose how many lines you want to fill, \nPLEASE ENTER JUST AN INTEGER NUMBER!!!!");
        int lines = ChekerForCorrectInput.CheckIfInteger();
        return lines;
    }
}