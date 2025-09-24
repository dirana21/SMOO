internal class Program
{
    public static void Function(StreamWriter writer, float xmin /* -2 */, float xmax /* 2 */, float dot)
    {
        double Y = 0;
        float step = (xmax - xmin) / dot;
        for (float x = xmin; x <= xmax; x += step)
        {
            Y = Math.Pow(x,3) * Math.Pow(Math.Cos(x+3), 2);
            writer.WriteLine($"Для заданої функції Y({x, 5:F2})= {Y, -10:F4}");
        }
    }
    
    static void Main(string[] args)
    {
        const string name = "Левченко Дмитро Володимирович";
        string[] lines = File.ReadAllLines("input.txt");
        float[] value = new float[lines.Length];
        for (int i = 0; i < value.Length; i++)
        {
            value[i] = float.Parse(lines[i]);
        }
        float y = value[0], x= value[1], xmin = value[2], xmax = value[3];
        float dot = 8;
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            Function(writer,xmin, xmax, dot);
            writer.WriteLine($"Розрахував студент группи КН24-1 {name}");
        }
    }
}