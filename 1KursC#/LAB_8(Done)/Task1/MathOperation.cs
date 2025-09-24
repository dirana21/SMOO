namespace Task1
{
    public class MathOperation
    {
        public static bool IsPrime(int number)
        {
            Console.WriteLine("Is prime?");
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++) 
                if (number % i == 0) return false;
            return true;
        }

        static bool isPerfectSquare(int x)
        {
            int s = (int)Math.Sqrt(x);
            return s * s == x;
        }

        public static bool IsFibonacci(int n)
        {
            Console.WriteLine("Is fibonacci?");
            return isPerfectSquare(5 * n * n +4) || isPerfectSquare(5 * n * n - 4);
        }

        private static double GetTriangleArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        private static double GetRectanglePerimeter(double a, double b)
        {
            return a + b;
        }

        public static string GetFormule(double[] args)
        {
            switch (args.Length)
            {
                case 2:
                    return GetRectanglePerimeter(args[0], args[1]).ToString();
                case 3:
                    return GetTriangleArea(args[0], args[1], args[2]).ToString();
                default:
                    throw new ArgumentException("Unsupported number of arguments.");
            }
        }
    }   
}