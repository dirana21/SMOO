namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] x = { 1, 9, -15 };
            Console.WriteLine(" x\t S(x) (Approx.)\t y(x) = e^x\t Error");
            foreach (double X in x)
            {
                double seriesSum = Calculate.CalculateS(X);
                double exactValue = Math.Exp(X);
                double error = Math.Abs(seriesSum - exactValue);

                Console.WriteLine($"{X}\t {seriesSum:F6}\t {exactValue:F6}\t {error:E}");
            }
        }
    }
}

