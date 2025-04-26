namespace Task1
{
    public class AllCalculation
    {
        public static void MathsCalclation(Circle[] circle)
        {
            Console.WriteLine("\t Show any Figure");
            foreach (var obj in circle)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("\t Show Calculate area of a figure");
            foreach (var obj in circle)
            {
                CalculateArea.Calculate(obj);
            }
            
            Console.WriteLine("\t Show Calculate Perimetr of a figure");
            foreach (var obj in circle)
            {
                CalculatePerimetr.Calculate(obj);
            }
        }
    }
}

