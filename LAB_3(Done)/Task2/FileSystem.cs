namespace Task2
{
    public class FileSystem
    {
        public static string DialogueFile()
        {
            string[] lines = File.ReadAllLines("Dialogue.txt");
            string dialogue = string.Join("\n", lines);
            return dialogue;
        }
        public static double[][] InputByFile()
        {
            string[] lines = File.ReadAllLines("input.txt");
            double[][] array = new double[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split(' ');
                List<double> row = new List<double>();

                foreach (string num in numbers)
                {
                    int j = 0;
                    if (double.TryParse(num, out double parsedNum))
                    {
                        row.Add(Math.Round(Math.Sin((i + 1) + (j + 1)) * parsedNum, 2));
                    }
                    else
                    {
                        Console.WriteLine($"Erro cannot read:  '{num}' в строке {i + 1}");
                        return null;
                    }
                }

                array[i] = row.ToArray();
            }

            return array;
        }
    }
}

