namespace Task1
{
    public class Oval : Circle
    {
        private double minorRadius;
        public double MinorRadius { get => minorRadius; set => minorRadius = value; }
        public Oval(double minorRadius, double radius, Point center) : base(radius, center)
        {
            MinorRadius = minorRadius;
        }

        public Oval() : this(0, 0, new Point(0, 0))
        {
            minorRadius = 0;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * minorRadius;
        }

        public override double CalculatePerimeter()
        {
            return (2 * Math.PI) * Math.Sqrt(((Radius * Radius) + (minorRadius * minorRadius)) / 2.0 );
        }
        
        public override string ToString()
        {
            return $"Oval: Center = {Center}, Minor Radius = {minorRadius}, Major Radius = {Radius}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Oval ov = (Oval)obj;
            return Radius == ov.Radius && MinorRadius == ov.MinorRadius && Center.Equals(ov.Center);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Radius, MinorRadius, Center);
        }
    }
}

