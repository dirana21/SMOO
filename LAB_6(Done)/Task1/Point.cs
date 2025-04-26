namespace Task1
{
    public class Point
    {
        private double centerX, centerY;
        public double CenterX { get => centerX; set => centerX = value; }
        public double CenterY { get => centerY; set => centerY = value; }

        public Point(double x , double y)
        {
            centerX = x;
            centerY = y;
        }
        
        public Point()
        {
            centerX = 0;
            centerY = 0;
        }

        public override string ToString()
        {
            return $"(x={CenterX}, y={CenterY})";
        }
    }
}

