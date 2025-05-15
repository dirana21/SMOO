using System.Diagnostics;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action act = Data.DataTime;
            act += Data.Date;
            act += Data.DataWeek;
            act();

            List<Predicate<int>> checks = new List<Predicate<int>>()
            {
                MathOperation.IsPrime,
                MathOperation.IsFibonacci
            };

            foreach (var check in checks)
            {
                Console.WriteLine(check(0));
            }

            Func<double[], string> perimetrFigure = MathOperation.GetFormule;
            string Call(Func<double[], string> func, params double[] args)
            {
                string result = func(args);
                Console.WriteLine(result);
                return result;
            }
            
            Call(perimetrFigure, 2, 3);
            Call(perimetrFigure, 3, 4, 5);
        }
    }
}

