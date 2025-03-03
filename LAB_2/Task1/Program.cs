namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] a = { 0.5, 0.75, 1.0, 1.25 };
            double xStart = 1, xEnd = 7, dx = 0.25 , y;
            const double E = 2.718281828459;
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"Для значення a: {a[i]}");
                for (double x = xStart; x <= xEnd; x += dx)
                {
                    y = Math.Pow(a[i] * Math.Pow(x, 2 ), 1.0/3.0 ) + Math.Pow(E, Math.Pow(-x, 2)) / Math.Sqrt(a[i]+1 * x);
                    Console.WriteLine($"x = {x, 2:F2}, y = {y, 2:F5}");
                }
            }
        }
    }
}
