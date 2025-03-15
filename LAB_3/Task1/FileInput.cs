namespace Task1
{
    public class FileInput
    {
        public static int[] InputByFile()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int[] array = new int[lines.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (int.TryParse(lines[i], out array[i]));
                else
                {
                    Console.WriteLine("I cannot read your input, file have another type not integer.");
                    return null;
                }
            }
            return array;
        }
    }
}

