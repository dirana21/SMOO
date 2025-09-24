namespace Task1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Circle circle1 = new Circle(2,new Point(2, 4));
            Circle circle2 = new Circle(4,new Point(4, 6));
            Circle circle3 = new Circle(6,new Point(6, 8));

            Oval oval1 = new Oval(2, 4, new Point(8, 10));
            Oval oval2 = new Oval(4, 8, new Point(10, 12));
            Oval oval3 = new Oval(6, 12, new Point(12, 14));
            
            Circle[] figure = new Circle[] { circle1, circle2, circle3, oval1, oval2, oval3 };
            AllCalculation.MathsCalclation(figure);
        }
    }
}

