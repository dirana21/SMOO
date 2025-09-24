namespace Task1
{
    public class Circle
    {
        private double radius;
        private Point center;
        
        public double Radius { get => radius; set => radius = value; }
        public Point Center { get => center; set => center = value; }

        public Circle(double radius, Point center)
        {
            Radius = radius;
            Center = center;
        }

        public Circle()
        {
            Radius = 0;
            Center = new Point(0, 0);
        }
        public virtual double CalculateArea()
        {
            return Math.PI * (radius * radius);
        }

        public virtual double CalculatePerimeter()
        {
            return (2 * Math.PI) * radius;
        }

        public void SetCenter(double x, double y)
        {
            center = new Point(x, y);
        }

        public override string ToString()
        {
            return $"Circle: Center = {center}, Radius = {radius}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            
            Circle circ = (Circle)obj;
            return Radius ==  circ.Radius && Center.Equals(circ.Center);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Radius, Center);
        }
    }
}

